using API.Errors;
using System.Net;
using System.Text.Json;

namespace API.MiddleWare
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _siguiente;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate siguiente, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            this._siguiente = siguiente;
            this._logger = logger;
            this._env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Si no hay alguna exception queremos que el middleware siga
                await _siguiente(context);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // Error 500

                // Si estamos en development devuelve el stack trace de la exception, si no solo devuelve el error 500
                var respuesta = _env.IsDevelopment() ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString()) : new ApiException((int)HttpStatusCode.InternalServerError);

                var json = JsonSerializer.Serialize(respuesta);

                await context.Response.WriteAsync(json);
            }
        }
    }
}