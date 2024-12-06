using API.Dtos.EntradaMercacia;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Authorize]
    public class EntradaMercanciaController : BaseApiController
    {
        private readonly IGenericRepository<EntradaMercancia> _entradaMercanciaRepo;
        private readonly IMapper _mapper;

        public EntradaMercanciaController(IGenericRepository<EntradaMercancia> entradaMercanciaRepo, IMapper mapper)
        {
            this._entradaMercanciaRepo = entradaMercanciaRepo;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<EntradaMercanciaDto>>> ObtenerEntradas()
        {
            var entradas = await _entradaMercanciaRepo.ObtenerTodosAsync();

            var entradasDto = _mapper.Map<IReadOnlyList<EntradaMercancia>, IReadOnlyList<EntradaMercanciaDto>>(entradas);

            return Ok(entradasDto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<EntradaMercanciaDto>>> ObtenerEntradaPorId(int id)
        {
            var entrada = await _entradaMercanciaRepo.ObtenerPorIdAsync(id);

            if(entrada == null)
            {
                return NotFound(new ApiRespuesta(404));
            }

            var entradaDto = _mapper.Map<EntradaMercancia, EntradaMercanciaDto>(entrada);

            return Ok(entradaDto);
        }

        [HttpPost]
        public async Task<ActionResult<EntradaMercancia>> CrearEntrada(EntradaMercanciaDto request)
        {
            var respuesta = await _entradaMercanciaRepo.AgregarAsync(_mapper.Map<EntradaMercanciaDto, EntradaMercancia>(request));

            return CreatedAtAction(
                nameof(CrearEntrada),
                new { id = respuesta.Id },
                value: respuesta);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EntradaMercancia>> ActualizarEntrada(int id, EntradaMercanciaActualizarDto request)
        {
            request.Id = id;

            await _entradaMercanciaRepo.ActualizarAsync(_mapper.Map<EntradaMercanciaActualizarDto, EntradaMercancia>(request));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EntradaMercancia>> BorrarEntrada(int id)
        {
            var response = await _entradaMercanciaRepo.BorrarAsync(id);

            if(response == null) return NotFound(new ApiRespuesta(404));

            return Ok(new ApiRespuesta(200, "Fue borrado exitosamente"));
        }
    }
}