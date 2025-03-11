using DesafioAssistencia.Models;

namespace Assistencia.Repositories
{
    public interface IPlanoAssistenciaRepository
    {
        Task<IEnumerable<PlanoAssistencia>> GetAllAsync();
        Task<PlanoAssistencia> GetByIdAsync(int id);
        Task AddAsync(PlanoAssistencia plano);
        Task UpdateAsync(PlanoAssistencia plano);
        Task DeleteAsync(int id);
    }
}
