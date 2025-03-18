using DesafioAssistencia.Models;

namespace Assistencia.Repositories
{
    public interface IEmpresaAssistenciaRepository
    {
        Task<IEnumerable<EmpresaAssistencia>> GetAllAsync();
        Task<EmpresaAssistencia> GetByIdAsync(int id);
        Task AddAsync(EmpresaAssistencia empresa);
        Task UpdateAsync(EmpresaAssistencia empresa);
        Task DeleteAsync(int id);
    }
}
