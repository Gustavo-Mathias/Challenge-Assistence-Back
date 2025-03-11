using Assistencia.Repositories;
using DesafioAssistencia.Models;

namespace Assistencia.Services
{
    public class GrupoVeiculoService
    {
        private readonly IGrupoVeiculoRepository _grupoVeiculoRepository;

        public GrupoVeiculoService(IGrupoVeiculoRepository grupoVeiculoRepository)
        {
            _grupoVeiculoRepository = grupoVeiculoRepository;
        }

        public async Task<IEnumerable<GrupoVeiculo>> GetAllAsync()
        {
            return await _grupoVeiculoRepository.GetAllAsync();
        }

        public async Task<GrupoVeiculo> GetByIdAsync(int id)
        {
            return await _grupoVeiculoRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(GrupoVeiculo grupo)
        {
            await _grupoVeiculoRepository.AddAsync(grupo);
        }

        public async Task UpdateAsync(GrupoVeiculo grupo)
        {
            await _grupoVeiculoRepository.UpdateAsync(grupo);
        }

        public async Task DeleteAsync(int id)
        {
            await _grupoVeiculoRepository.DeleteAsync(id);
        }
    }
}
