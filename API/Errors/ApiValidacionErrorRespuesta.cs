namespace API.Errors
{
    public class ApiValidacionErrorRespuesta : ApiRespuesta
    {
        public ApiValidacionErrorRespuesta() : base(400)
        {
        }

        public List<string> Errors { get; set; }
    }
}