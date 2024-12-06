using API.Errors;
using Infractructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ErroresController : BaseApiController
    {
        private readonly InventarioManufacturaContext _context;

        public ErroresController(InventarioManufacturaContext context)
        {
            this._context = context;
        }

        [HttpGet("notfound")]
        public ActionResult ObtenerNotFound()
        {
            // Obteniendo un producto que no exite deliberadamente para simular un error de Not found
            var productoNoExiste = _context.Productos.Find(9999999);

            if(productoNoExiste == null)
            {
                return NotFound(new ApiRespuesta(404));
            }

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult ObtenerServerError()
        {
            var productoNoExiste = _context.Productos.Find(9999999);

            // Esto genera un error porque no se puede usar el metodo .ToString() en un object que no existe/null.
            var productoADevolver = productoNoExiste.ToString();

            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult ObtenerBadRequest()
        {
            return BadRequest(new ApiRespuesta(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult ObtenerNotFound(int id)
        {
            return Ok();
        }

    }
}