using DesafioAssistencia.Data;
using DesafioAssistencia.Models;
using Microsoft.EntityFrameworkCore;

namespace Assistencia.Repositories
{
    public class PlanoAssistenciaRepository : IPlanoAssistenciaRepository
    {
        private readonly AppDbContext _context;

        public PlanoAssistenciaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlanoAssistencia>> GetAllAsync()
        {
            return await _context.PlanosAssistencia.ToListAsync();
        }

        public async Task<PlanoAssistencia> GetByIdAsync(int id)
        {
            return await _context.PlanosAssistencia.FindAsync(id);
        }

        public async Task AddAsync(PlanoAssistencia plano)
        {
            await _context.PlanosAssistencia.AddAsync(plano);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PlanoAssistencia plano)
        {
            _context.PlanosAssistencia.Update(plano);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var plano = await _context.PlanosAssistencia.FindAsync(id);
            if (plano != null)
            {
                _context.PlanosAssistencia.Remove(plano);
                await _context.SaveChangesAsync();
            }
        }
    }
}
