using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infractructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsuariosAsync(UserManager<Usuario> manager)
        {
            if(!manager.Users.Any())
            {
                var usuario = new Usuario
                {
                    NombreAMostrar = "Andres Rodriguez",
                    Email = "andres.rodriguez@test.com",
                    UserName = "andres.rodriguez@test.com"
                };

                await manager.CreateAsync(usuario, "Pa$$w0rd");
            }
        }
    }
}