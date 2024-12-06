namespace API.Dtos.ProductoDefectuosos
{
    public class ProductoDefectuosoActualizarDto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public DateTime FechaReportado { get; set; }
    }
}