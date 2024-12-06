using System.ComponentModel.DataAnnotations;

namespace API.Dtos.ProductoDefectuosos
{
    public class ProductoDefectuosoCrearDTo
    {
        [Required]

        public int ProductoId { get; set; }
        [Required]

        public DateTime FechaReportado { get; set; }
    }
}