using Assistencia.Repositories;
using DesafioAssistencia.Models;

namespace Assistencia.Services
{
    public class PlanoAssistenciaService
    {
        private readonly IPlanoAssistenciaRepository _planoRepository;

        public PlanoAssistenciaService(IPlanoAssistenciaRepository planoRepository)
        {
            _planoRepository = planoRepository;
        }

        public async Task<IEnumerable<PlanoAssistencia>> GetAllAsync()
        {
            return await _planoRepository.GetAllAsync();
        }

        public async Task<PlanoAssistencia> GetByIdAsync(int id)
        {
            return await _planoRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(PlanoAssistencia plano)
        {
            await _planoRepository.AddAsync(plano);
        }

        public async Task UpdateAsync(PlanoAssistencia plano)
        {
            await _planoRepository.UpdateAsync(plano);
        }

        public async Task DeleteAsync(int id)
        {
            await _planoRepository.DeleteAsync(id);
        }
    }
}
