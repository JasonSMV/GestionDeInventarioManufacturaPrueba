using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infractructure;

public class InventarioManufacturaContext : DbContext
{
    public InventarioManufacturaContext(DbContextOptions<InventarioManufacturaContext> options) : base(options)
    {
    }

    public DbSet<Producto> Productos { get; set; }
    public DbSet<TipoDeElaboracion> TipoDeElaboraciones { get; set; }
    public DbSet<Estado> Estados { get; set; }
    public DbSet<EntradaMercancia> EntradaMercancia { get; set; }
    public DbSet<SalidaMercancia> SalidaMercancia { get; set; }
    public DbSet<ProductosDefectuosos> ProductosDefectuosos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Aplicando las configuraciones/restricciones setiadas en Cofig
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}