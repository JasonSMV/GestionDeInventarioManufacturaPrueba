using API.Helpers;
using API.MiddleWare;
using Core.Entities.Identity;
using Core.Interfaces;
using Infractructure;
using Infractructure.Data;
using Infractructure.Identity;
using Infractructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<InventarioManufacturaContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<AppIdentityDbContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("IdentityConnection")));

builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));

// Servicio que general el token jwt
builder.Services.AddScoped<ITokenService, TokenService>();

// Se pasa como parametro la ubicacion(assembly) de los perfiles de mapeo.
builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()  // Allow any origin (use with caution, not recommended for production)
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddIdentityCore<Usuario>().AddEntityFrameworkStores<AppIdentityDbContext>().AddSignInManager<SignInManager<Usuario>>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:Key"])),
        ValidIssuer = builder.Configuration["Token:Issuer"],
        ValidateIssuer = true,
        ValidateAudience = false
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "JWT Auth Bearer",
        Name = "Auhorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securitySchema);
    var securityRequerimientos = new OpenApiSecurityRequirement{
        {securitySchema, new [] { "Bearer"} }
        };

    c.AddSecurityRequirement(securityRequerimientos);

});

var app = builder.Build();

// Aplica la migraciones cuando se inicia la app (aplica a migraciones pendientes)
using(var scope = app.Services.CreateScope())
{
    var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();

    try
    {
        var context = scope.ServiceProvider.GetRequiredService<InventarioManufacturaContext>();

        // Aplica migraciones pendientes.
        await context.Database.MigrateAsync();

        // Se llama el metodo Seed para llenar la db con data.

        await InventarioManufacturadoContextSeed.SeedAsync(context, loggerFactory);

        // seed data para usuario

        var managerUsuarios = scope.ServiceProvider.GetRequiredService<UserManager<Usuario>>();
        var identityContext = scope.ServiceProvider.GetRequiredService<AppIdentityDbContext>();

        await identityContext.Database.MigrateAsync();
        await AppIdentityDbContextSeed.SeedUsuariosAsync(managerUsuarios);
    }
    catch(Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "Un error ocurrio durante la migracion");
    }
}

// Configure the HTTP request pipeline.

// Se agrega middleware para manejar error del servidor y mandar un respuesta de error consistente
app.UseMiddleware<ExceptionMiddleware>();

app.UseCors("AllowAll");

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();