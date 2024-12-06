using API.Dtos.Estados;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Authorize]
    public class EstadosController : BaseApiController
    {
        private readonly IGenericRepository<Estado> _estadosRepo;
        private readonly IMapper _mapper;

        public EstadosController(IGenericRepository<Estado> estadosRepo, IMapper mapper)
        {
            this._estadosRepo = estadosRepo;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<EstadoADevolverDTo>>> ObtenerEstados()
        {
            var estados = await _estadosRepo.ObtenerTodosAsync();

            var estadosDto = _mapper.Map<IReadOnlyList<Estado>, IReadOnlyList<EstadoADevolverDTo>>(estados);

            return Ok(estadosDto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<EstadoADevolverDTo>>> ObtenerEstadoPorId(int id)
        {
            var estado = await _estadosRepo.ObtenerPorIdAsync(id);

            if(estado == null)
            {
                return NotFound(new ApiRespuesta(404));
            }

            var estadoDto = _mapper.Map<Estado, EstadoADevolverDTo>(estado);

            return Ok(estadoDto);
        }

        [HttpPost]
        public async Task<ActionResult<Estado>> CrearEstado(EstadoADevolverDTo request)
        {
            var respuesta = await _estadosRepo.AgregarAsync(_mapper.Map<EstadoADevolverDTo, Estado>(request));

            return CreatedAtAction(
                nameof(CrearEstado),
                new { id = respuesta.Id },
                value: respuesta);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Estado>> ActualizarEstado(int id, EstadoActualizarDto request)
        {
            request.Id = id;

            await _estadosRepo.ActualizarAsync(_mapper.Map<EstadoActualizarDto, Estado>(request));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Estado>> BorrarEstado(int id)
        {
            var response = await _estadosRepo.BorrarAsync(id);

            if(response == null) return NotFound(new ApiRespuesta(404));

            return Ok(new ApiRespuesta(200, "Fue borrado exitosamente"));
        }
    }
}