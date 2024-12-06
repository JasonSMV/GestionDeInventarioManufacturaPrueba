using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity
{
    public class Usuario : IdentityUser
    {
        public string NombreAMostrar { get; set; }
    }
}