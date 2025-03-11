using Assistencia.Repositories;
using DesafioAssistencia.Models;

namespace Assistencia.Services
{
    public class VeiculoAssistenciaService
    {
        private readonly IVeiculoAssistenciaRepository _veiculoAssistenciaRepository;

        public VeiculoAssistenciaService(IVeiculoAssistenciaRepository veiculoAssistenciaRepository)
        {
            _veiculoAssistenciaRepository = veiculoAssistenciaRepository;
        }

        public async Task<IEnumerable<VeiculoAssistencia>> GetAllAsync()
        {
            return await _veiculoAssistenciaRepository.GetAllAsync();
        }

        public async Task<VeiculoAssistencia> GetByIdAsync(int veiculoId, int planoId)
        {
            return await _veiculoAssistenciaRepository.GetByIdAsync(veiculoId, planoId);
        }

        public async Task AddAsync(VeiculoAssistencia veiculoAssistencia)
        {
            await _veiculoAssistenciaRepository.AddAsync(veiculoAssistencia);
        }

        public async Task DeleteAsync(int veiculoId, int planoId)
        {
            await _veiculoAssistenciaRepository.DeleteAsync(veiculoId, planoId);
        }
    }
}
