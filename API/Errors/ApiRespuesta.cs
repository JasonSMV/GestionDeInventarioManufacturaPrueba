namespace API.Errors
{
    public class ApiRespuesta
    {
        public ApiRespuesta(int codigoEstado, string mensaje = null)
        {
            Codigo = codigoEstado;
            Mensaje = mensaje ?? ObtenerMensajePorDefectoParaCodigoDeEstado(Codigo);
        }

        public int Codigo { get; set; }
        public string Mensaje { get; set; }

        private string ObtenerMensajePorDefectoParaCodigoDeEstado(int codigoEstado)
        {
            return codigoEstado switch
            {
                400 => "Bad Request",
                401 => "No Autorizado",
                404 => "Not Found",
                500 => "Server error",
                _ => null
            };
        }
    }
}