using Assistencia.Services;
using DesafioAssistencia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assistencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly VeiculoService _veiculoService;

        public VeiculoController(VeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetAll()
        {
            var veiculos = await _veiculoService.GetAllAsync();
            return Ok(veiculos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo>> GetById(int id)
        {
            var veiculo = await _veiculoService.GetByIdAsync(id);
            if (veiculo == null) return NotFound();
            return Ok(veiculo);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Veiculo veiculo)
        {
            await _veiculoService.AddAsync(veiculo);
            return CreatedAtAction(nameof(GetById), new { id = veiculo.Id }, veiculo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Veiculo veiculo)
        {
            if (id != veiculo.Id) return BadRequest();
            await _veiculoService.UpdateAsync(veiculo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _veiculoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
