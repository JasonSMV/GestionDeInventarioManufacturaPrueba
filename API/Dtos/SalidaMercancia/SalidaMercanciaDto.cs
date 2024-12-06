namespace API.Dtos.SalidaMercancia
{
    public class SalidaMercanciaDto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public DateTime FechaDeSalida { get; set; }
    }
}