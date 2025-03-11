using Assistencia.Services;
using DesafioAssistencia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assistencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoAssistenciaController : ControllerBase
    {
        private readonly VeiculoAssistenciaService _veiculoAssistenciaService;

        public VeiculoAssistenciaController(VeiculoAssistenciaService veiculoAssistenciaService)
        {
            _veiculoAssistenciaService = veiculoAssistenciaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiculoAssistencia>>> GetAll()
        {
            var veiculosAssistencia = await _veiculoAssistenciaService.GetAllAsync();
            return Ok(veiculosAssistencia);
        }

        [HttpGet("{veiculoId}/{planoId}")]
        public async Task<ActionResult<VeiculoAssistencia>> GetById(int veiculoId, int planoId)
        {
            var veiculoAssistencia = await _veiculoAssistenciaService.GetByIdAsync(veiculoId, planoId);
            if (veiculoAssistencia == null) return NotFound();
            return Ok(veiculoAssistencia);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] VeiculoAssistencia veiculoAssistencia)
        {
            await _veiculoAssistenciaService.AddAsync(veiculoAssistencia);
            return CreatedAtAction(nameof(GetById), new { veiculoId = veiculoAssistencia.VeiculoId, planoId = veiculoAssistencia.PlanoId }, veiculoAssistencia);
        }

        [HttpDelete("{veiculoId}/{planoId}")]
        public async Task<ActionResult> Delete(int veiculoId, int planoId)
        {
            await _veiculoAssistenciaService.DeleteAsync(veiculoId, planoId);
            return NoContent();
        }
    }
}
