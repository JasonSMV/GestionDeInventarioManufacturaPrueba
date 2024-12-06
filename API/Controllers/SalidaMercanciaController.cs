using API.Dtos.SalidaMercancia;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]

    public class SalidaMercanciaController : BaseApiController
    {
        private readonly IGenericRepository<SalidaMercancia> _salidaMercanciaRepo;
        private readonly IMapper _mapper;

        public SalidaMercanciaController(IGenericRepository<SalidaMercancia> salidaMercanciaRepo, IMapper mapper)
        {
            this._salidaMercanciaRepo = salidaMercanciaRepo;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<SalidaMercanciaDto>>> ObtenerSalidas()
        {
            var salidas = await _salidaMercanciaRepo.ObtenerTodosAsync();

            var salidasDto = _mapper.Map<IReadOnlyList<SalidaMercancia>, IReadOnlyList<SalidaMercanciaDto>>(salidas);

            return Ok(salidasDto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<SalidaMercanciaDto>>> ObtenerSalidaPorId(int id)
        {
            var salida = await _salidaMercanciaRepo.ObtenerPorIdAsync(id);

            if(salida == null)
            {
                return NotFound(new ApiRespuesta(404));
            }

            var salidaDto = _mapper.Map<SalidaMercancia, SalidaMercanciaDto>(salida);

            return Ok(salidaDto);
        }

        [HttpPost]
        public async Task<ActionResult<SalidaMercanciaDto>> CrearSalida(SalidaMercanciaDto request)
        {
            var respuesta = await _salidaMercanciaRepo.AgregarAsync(_mapper.Map<SalidaMercanciaDto, SalidaMercancia>(request));

            return CreatedAtAction(
                nameof(CrearSalida),
                new { id = respuesta.Id },
                value: respuesta);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SalidaMercanciaDto>> ActualizarSalida(int id, SalidaMercanciaActualizarDto request)
        {
            request.Id = id;

            await _salidaMercanciaRepo.ActualizarAsync(_mapper.Map<SalidaMercanciaActualizarDto, SalidaMercancia>(request));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SalidaMercanciaDto>> BorrarSalida(int id)
        {
            var response = await _salidaMercanciaRepo.BorrarAsync(id);

            if(response == null) return NotFound(new ApiRespuesta(404));

            return Ok(new ApiRespuesta(200, "Fue borrado exitosamente"));
        }
    }
}