namespace API.Dtos.ProductoDefectuosos
{
    public class ProductosDefectusosDto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public DateTime FechaReportado { get; set; }
    }
}