using DesafioAssistencia.Models;

namespace Assistencia.Repositories
{
    public interface IGrupoVeiculoRepository
    {
        Task<IEnumerable<GrupoVeiculo>> GetAllAsync();
        Task<GrupoVeiculo> GetByIdAsync(int id);
        Task AddAsync(GrupoVeiculo grupo);
        Task UpdateAsync(GrupoVeiculo grupo);
        Task DeleteAsync(int id);
    }
}
