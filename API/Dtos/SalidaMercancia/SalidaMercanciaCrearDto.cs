using System.ComponentModel.DataAnnotations;

namespace API.Dtos.SalidaMercancia
{
    public class SalidaMercanciaCrearDto
    {
        [Required]

        public int ProductoId { get; set; }
        [Required]

        public DateTime FechaDeSalida { get; set; }
    }
}