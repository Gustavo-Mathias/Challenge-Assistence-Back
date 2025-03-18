using DesafioAssistencia.Models;

namespace Assistencia.Repositories
{
    public interface IVeiculoAssistenciaRepository
    {
        Task<IEnumerable<VeiculoAssistencia>> GetAllAsync();
        Task<VeiculoAssistencia> GetByIdAsync(int veiculoId, int planoId);
        Task AddAsync(VeiculoAssistencia veiculoAssistencia);
        Task DeleteAsync(int veiculoId, int planoId);
    }
}
