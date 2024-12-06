using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Usuarios
{
    public class LoginDto
    {
        [Required]

        public string Email { get; set; }
        [Required]
        public string Contrasena { get; set; }
    }
}