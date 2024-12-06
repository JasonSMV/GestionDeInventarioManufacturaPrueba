namespace Core.Entities;

public class ProductosDefectuosos : BaseEntity
{
    public Producto Producto { get; set; }
    public int ProductoId { get; set; }
    public DateTime FechaReportado { get; set; }
}