namespace API.Errors
{
    public class ApiException : ApiRespuesta
    {
        public ApiException(int codigoEstado, string mensaje = null, string detalles = null) : base(codigoEstado, mensaje)
        {
            Detalles = detalles;
        }

        public string Detalles { get; set; }
    }
}
