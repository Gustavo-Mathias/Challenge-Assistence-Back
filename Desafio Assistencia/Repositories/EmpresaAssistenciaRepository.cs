using DesafioAssistencia.Data;
using DesafioAssistencia.Models;
using Microsoft.EntityFrameworkCore;

namespace Assistencia.Repositories
{
    public class EmpresaAssistenciaRepository : IEmpresaAssistenciaRepository
    {
        private readonly AppDbContext _context;

        public EmpresaAssistenciaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmpresaAssistencia>> GetAllAsync()
        {
            return await _context.EmpresasAssistencia.ToListAsync();
        }

        public async Task<EmpresaAssistencia> GetByIdAsync(int id)
        {
            return await _context.EmpresasAssistencia.FindAsync(id);
        }

        public async Task AddAsync(EmpresaAssistencia empresa)
        {
            await _context.EmpresasAssistencia.AddAsync(empresa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmpresaAssistencia empresa)
        {
            _context.EmpresasAssistencia.Update(empresa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var empresa = await _context.EmpresasAssistencia.FindAsync(id);
            if (empresa != null)
            {
                _context.EmpresasAssistencia.Remove(empresa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
