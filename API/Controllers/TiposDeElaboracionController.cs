using API.Dtos.TiposDeElaboracion;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]

    public class TiposDeElaboracionController : BaseApiController
    {
        private readonly IGenericRepository<TipoDeElaboracion> _tiposDeElaboracionRepo;
        private readonly IMapper _mapper;

        public TiposDeElaboracionController(IGenericRepository<TipoDeElaboracion> tiposDeElaboracion, IMapper mapper)
        {
            this._tiposDeElaboracionRepo = tiposDeElaboracion;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoDeElaboracion>>> ObtenerTiposDeElaboracion()
        {
            var tiposDeElaboracion = await _tiposDeElaboracionRepo.ObtenerTodosAsync();

            var tiposDeElaboracionDto = _mapper.Map<IReadOnlyList<TipoDeElaboracion>, IReadOnlyList<Dtos.TiposDeElaboracion.TiposDeElaboracionDTo>>(tiposDeElaboracion);

            return Ok(tiposDeElaboracionDto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<TipoDeElaboracion>>> ObtenerTiposDeElaboracionPorId(int id)
        {
            var tiposDeElaboracion = await _tiposDeElaboracionRepo.ObtenerPorIdAsync(id);

            if(tiposDeElaboracion == null)
            {
                return NotFound(new ApiRespuesta(404));
            }

            var tiposDeElaboracionDto = _mapper.Map<TipoDeElaboracion, TiposDeElaboracionDTo>(tiposDeElaboracion);

            return Ok(tiposDeElaboracionDto);
        }

        [HttpPost]
        public async Task<ActionResult<TipoDeElaboracion>> CrearTipoDeElaboracion(TiposDeElaboracionDTo request)
        {
            var respuesta = await _tiposDeElaboracionRepo.AgregarAsync(_mapper.Map<TiposDeElaboracionDTo, TipoDeElaboracion>(request));

            return CreatedAtAction(
                nameof(CrearTipoDeElaboracion),
                new { id = respuesta.Id },
                value: respuesta);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TipoDeElaboracion>> ActualizarTipoDeElaboracion(int id, TiposDeElaboracionActualizar request)
        {
            request.Id = id;

            await _tiposDeElaboracionRepo.ActualizarAsync(_mapper.Map<TiposDeElaboracionActualizar, TipoDeElaboracion>(request));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoDeElaboracion>> BorrarTipoDeElaboracion(int id)
        {
            var response = await _tiposDeElaboracionRepo.BorrarAsync(id);

            if(response == null) return NotFound(new ApiRespuesta(404));

            return Ok(new ApiRespuesta(200, "Fue borrado exitosamente"));
        }
    }
}