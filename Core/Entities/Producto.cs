namespace Core.Entities;

public class Producto : BaseEntity
{
    public string Nombre { get; set; }
    public TipoDeElaboracion TipoDeElaboracion { get; set; }
    public int TipoDeElaboracionId { get; set; }
    public Estado Estado { get; set; }
    public int EstadoId { get; set; }
}