namespace API.Dtos.SalidaMercancia
{
    public class SalidaMercanciaActualizarDto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public DateTime FechaDeSalida { get; set; }
    }
}