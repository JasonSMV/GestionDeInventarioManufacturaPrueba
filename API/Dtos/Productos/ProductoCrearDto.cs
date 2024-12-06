using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Productos
{
    public class ProductoCrearDto
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public int TipoDeElaboracionId { get; set; }

        [Required]
        public int EstadoId { get; set; }
    }
}