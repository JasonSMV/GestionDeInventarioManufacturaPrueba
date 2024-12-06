namespace API.Dtos.EntradaMercacia
{
    public class EntradaMercanciaActualizarDto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public DateTime FechaEntrada { get; set; }
    }
}