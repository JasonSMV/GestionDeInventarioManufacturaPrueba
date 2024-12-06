using API.Dtos.Productos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]

    public class ProductosController : BaseApiController
    {
        private readonly IProductoRepository _productosRepo;
        private readonly IGenericRepository<TipoDeElaboracion> _tiposDeElaboracionRepo;
        private readonly IGenericRepository<Estado> _estadosRepo;
        private readonly IMapper _mapper;

        public ProductosController(IProductoRepository repo, IGenericRepository<TipoDeElaboracion> tiposDeElaboracionRepo, IGenericRepository<Estado> estadosRepo, IMapper mapper)
        {
            this._productosRepo = repo;
            this._tiposDeElaboracionRepo = tiposDeElaboracionRepo;
            this._estadosRepo = estadosRepo;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductosADevolverDto>>> ObtenerProductos()
        {
            var productos = await _productosRepo.ObtenerProductos();
            var productoDto = _mapper.Map<IReadOnlyList<Producto>, IReadOnlyList<ProductosADevolverDto>>(productos);

            return Ok(productoDto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<ProductosADevolverDto>>> ObtenerProductoPorId(int id)
        {
            var producto = await _productosRepo.ObtenerProductoPorId(id);

            if(producto == null)
            {
                return NotFound(new ApiRespuesta(404));
            }

            var productoDto = _mapper.Map<Producto, ProductosADevolverDto>(producto);

            return Ok(productoDto);
        }

        [HttpGet("estados")]
        public async Task<ActionResult<List<Producto>>> ObtenerEstadosDeProducto()
        {
            var estados = await _estadosRepo.ObtenerTodosAsync();
            return Ok(estados);
        }

        [HttpGet("tipos_de_elaboracion")]
        public async Task<ActionResult<List<Producto>>> ObtenerTiposDeElaboracionDeProducto()
        {
            var tipos = await _tiposDeElaboracionRepo.ObtenerTodosAsync();
            return Ok(tipos);
        }

        [HttpPost]
        public async Task<ActionResult<ProductoCrearDto>> CrearProducto(ProductoCrearDto request)
        {
            var respuesta = await _productosRepo.AgregarAsync(_mapper.Map<ProductoCrearDto, Producto>(request));

            return CreatedAtAction(
                nameof(CrearProducto),
                new { id = respuesta.Id },
                value: respuesta);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Producto>> BorrarProducto(int id)
        {
            var response = await _productosRepo.BorrarAsync(id);

            if(response == null) return NotFound(new ApiRespuesta(404));

            return Ok(new ApiRespuesta(200, "Fue borrado exitosamente"));
        }

        [HttpPost("crear-multiples")]
        public async Task<ActionResult<List<ProductoCrearDto>>> CrearMultiplesProductos(List<ProductoCrearDto> request)
        {
            var productos = new List<Producto>();

            foreach(var productoDto in request)
            {
                var producto = _mapper.Map<ProductoCrearDto, Producto>(productoDto);
                productos.Add(await _productosRepo.AgregarAsync(producto));
            }

            var productosDto = _mapper.Map<List<Producto>, List<ProductoCrearDto>>(productos);

            return CreatedAtAction(
                nameof(CrearMultiplesProductos),
                new { count = productos.Count },
                value: productosDto);
        }
    }
}