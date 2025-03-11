using Assistencia.Services;
using DesafioAssistencia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assistencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaAssistenciaController : ControllerBase
    {
        private readonly EmpresaAssistenciaService _empresaService;

        public EmpresaAssistenciaController(EmpresaAssistenciaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaAssistencia>>> GetAll()
        {
            var empresas = await _empresaService.GetAllAsync();
            return Ok(empresas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaAssistencia>> GetById(int id)
        {
            var empresa = await _empresaService.GetByIdAsync(id);
            if (empresa == null) return NotFound();
            return Ok(empresa);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EmpresaAssistencia empresa)
        {
            await _empresaService.AddAsync(empresa);
            return CreatedAtAction(nameof(GetById), new { id = empresa.Id }, empresa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] EmpresaAssistencia empresa)
        {
            if (id != empresa.Id) return BadRequest();
            await _empresaService.UpdateAsync(empresa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _empresaService.DeleteAsync(id);
            return NoContent();
        }
    }
}
