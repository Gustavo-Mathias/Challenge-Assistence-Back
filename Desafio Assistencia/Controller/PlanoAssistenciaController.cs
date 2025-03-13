using Assistencia.Models;
using Assistencia.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assistencia.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlanoAssistenciaController : ControllerBase
	{
		private readonly PlanoAssistenciaService _planoService;

		public PlanoAssistenciaController(PlanoAssistenciaService planoService)
		{
			_planoService = planoService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<PlanoAssistencia>>> GetAll()
		{
			var planos = await _planoService.GetAllAsync();
			return Ok(planos);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<PlanoAssistencia>> GetById(int id)
		{
			var plano = await _planoService.GetByIdAsync(id);
			if (plano == null) return NotFound();
			return Ok(plano);
		}

		[HttpPost]
		public async Task<ActionResult> Create([FromBody] PlanoAssistencia plano)
		{
			await _planoService.AddAsync(plano);
			return CreatedAtAction(nameof(GetById), new { id = plano.Id }, plano);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Update(int id, [FromBody] PlanoAssistencia plano)
		{
			if (id != plano.Id) return BadRequest();
			await _planoService.UpdateAsync(plano);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			await _planoService.DeleteAsync(id);
			return NoContent();
		}
	}
}
