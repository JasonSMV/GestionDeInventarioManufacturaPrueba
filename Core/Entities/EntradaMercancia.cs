namespace Core.Entities;

public class EntradaMercancia : BaseEntity
{
    public Producto Producto { get; set; }
    public int ProductoId { get; set; }
    public DateTime FechaEntrada { get; set; }
}