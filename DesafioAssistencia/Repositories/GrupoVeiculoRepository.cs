using DesafioAssistencia.Data;
using DesafioAssistencia.Models;
using Microsoft.EntityFrameworkCore;

namespace Assistencia.Repositories
{
    public class GrupoVeiculoRepository : IGrupoVeiculoRepository
    {
        private readonly AppDbContext _context;

        public GrupoVeiculoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GrupoVeiculo>> GetAllAsync()
        {
            return await _context.GruposVeiculos.ToListAsync();
        }

        public async Task<GrupoVeiculo> GetByIdAsync(int id)
        {
            return await _context.GruposVeiculos.FindAsync(id);
        }

        public async Task AddAsync(GrupoVeiculo grupo)
        {
            await _context.GruposVeiculos.AddAsync(grupo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GrupoVeiculo grupo)
        {
            _context.GruposVeiculos.Update(grupo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var grupo = await _context.GruposVeiculos.FindAsync(id);
            if (grupo != null)
            {
                _context.GruposVeiculos.Remove(grupo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
