using API.Dtos.ProductoDefectuosos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Authorize]

    public class ProductosDefectuososController : BaseApiController
    {
        private readonly IGenericRepository<ProductosDefectuosos> _productosDefectuososRepo;
        private readonly IMapper _mapper;

        public ProductosDefectuososController(IGenericRepository<ProductosDefectuosos> productosDefectuososRepo, IMapper mapper)
        {
            this._productosDefectuososRepo = productosDefectuososRepo;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductosDefectusosDto>>> ObtenerProductos()
        {
            var productos = await _productosDefectuososRepo.ObtenerTodosAsync();

            var productosDto = _mapper.Map<IReadOnlyList<ProductosDefectuosos>, IReadOnlyList<ProductosDefectusosDto>>(productos);

            return Ok(productosDto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<ProductosDefectusosDto>>> ObtenerProductoPorId(int id)
        {
            var producto = await _productosDefectuososRepo.ObtenerPorIdAsync(id);

            if(producto == null)
            {
                return NotFound(new ApiRespuesta(404));
            }

            var productoDto = _mapper.Map<ProductosDefectuosos, ProductosDefectusosDto>(producto);

            return Ok(productoDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductosDefectusosDto>> CrearProductoDefectuoso(ProductosDefectusosDto request)
        {
            var respuesta = await _productosDefectuososRepo.AgregarAsync(_mapper.Map<ProductosDefectusosDto, ProductosDefectuosos>(request));

            return CreatedAtAction(
                nameof(CrearProductoDefectuoso),
                new { id = respuesta.Id },
                value: respuesta);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductosDefectusosDto>> ActualizarProducto(int id, ProductoDefectuosoActualizarDto request)
        {
            request.Id = id;

            await _productosDefectuososRepo.ActualizarAsync(_mapper.Map<ProductoDefectuosoActualizarDto, ProductosDefectuosos>(request));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductosDefectusosDto>> BorrarProducto(int id)
        {
            var response = await _productosDefectuososRepo.BorrarAsync(id);

            if(response == null) return NotFound(new ApiRespuesta(404));

            return Ok(new ApiRespuesta(200, "Fue borrado exitosamente"));
        }
    }
}