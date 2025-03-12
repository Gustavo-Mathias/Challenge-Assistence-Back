using Assistencia.Services;
using DesafioAssistencia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assistencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoVeiculoController : ControllerBase
    {
        private readonly GrupoVeiculoService _grupoVeiculoService;

        public GrupoVeiculoController(GrupoVeiculoService grupoVeiculoService)
        {
            _grupoVeiculoService = grupoVeiculoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoVeiculo>>> GetAll()
        {
            var grupos = await _grupoVeiculoService.GetAllAsync();
            return Ok(grupos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoVeiculo>> GetById(int id)
        {
            var grupo = await _grupoVeiculoService.GetByIdAsync(id);
            if (grupo == null) return NotFound();
            return Ok(grupo);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] GrupoVeiculo grupo)
        {
            await _grupoVeiculoService.AddAsync(grupo);
            return CreatedAtAction(nameof(GetById), new { id = grupo.Id }, grupo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] GrupoVeiculo grupo)
        {
            if (id != grupo.Id) return BadRequest();
            await _grupoVeiculoService.UpdateAsync(grupo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _grupoVeiculoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
