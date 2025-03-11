using DesafioAssistencia.Data;
using DesafioAssistencia.Models;
using Microsoft.EntityFrameworkCore;

namespace Assistencia.Repositories
{
    public class VeiculoAssistenciaRepository : IVeiculoAssistenciaRepository
    {
        private readonly AppDbContext _context;

        public VeiculoAssistenciaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VeiculoAssistencia>> GetAllAsync()
        {
            return await _context.VeiculosAssistencia.ToListAsync();
        }

        public async Task<VeiculoAssistencia> GetByIdAsync(int veiculoId, int planoId)
        {
            return await _context.VeiculosAssistencia
                .FindAsync(veiculoId, planoId);
        }

        public async Task AddAsync(VeiculoAssistencia veiculoAssistencia)
        {
            await _context.VeiculosAssistencia.AddAsync(veiculoAssistencia);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int veiculoId, int planoId)
        {
            var veiculoAssistencia = await _context.VeiculosAssistencia
                .FindAsync(veiculoId, planoId);

            if (veiculoAssistencia != null)
            {
                _context.VeiculosAssistencia.Remove(veiculoAssistencia);
                await _context.SaveChangesAsync();
            }
        }
    }
}
