using System.ComponentModel.DataAnnotations;

namespace API.Dtos.EntradaMercacia
{
    public class EntradaMercanciaCrearDto
    {
        [Required]

        public int ProductoId { get; set; }
        [Required]

        public DateTime FechaEntrada { get; set; }
    }
}