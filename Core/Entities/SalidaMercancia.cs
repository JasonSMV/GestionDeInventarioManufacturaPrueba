namespace Core.Entities;

public class SalidaMercancia : BaseEntity
{
    public Producto Producto { get; set; }
    public int ProductoId { get; set; }
    public DateTime FechaDeSalida { get; set; }
}