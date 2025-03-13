using DesafioAssistencia.Models;

namespace Assistencia.Repositories
{
    public interface IVeiculoRepository
    {
        Task<IEnumerable<Veiculo>> GetAllAsync();
        Task<Veiculo> GetByIdAsync(int id);
        Task AddAsync(Veiculo veiculo);
        Task UpdateAsync(Veiculo veiculo);
        Task DeleteAsync(int id);
    }
}
