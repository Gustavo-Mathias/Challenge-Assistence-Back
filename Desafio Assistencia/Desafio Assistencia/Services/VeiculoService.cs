using Assistencia.Repositories;
using DesafioAssistencia.Models;

namespace Assistencia.Services
{
    public class VeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<IEnumerable<Veiculo>> GetAllAsync()
        {
            return await _veiculoRepository.GetAllAsync();
        }

        public async Task<Veiculo> GetByIdAsync(int id)
        {
            return await _veiculoRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Veiculo veiculo)
        {
            await _veiculoRepository.AddAsync(veiculo);
        }

        public async Task UpdateAsync(Veiculo veiculo)
        {
            await _veiculoRepository.UpdateAsync(veiculo);
        }

        public async Task DeleteAsync(int id)
        {
            await _veiculoRepository.DeleteAsync(id);
        }
    }
}
