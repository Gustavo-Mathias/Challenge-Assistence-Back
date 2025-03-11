using Assistencia.Repositories;
using DesafioAssistencia.Models;

namespace Assistencia.Services
{
    public class EmpresaAssistenciaService
    {
        private readonly IEmpresaAssistenciaRepository _empresaRepository;

        public EmpresaAssistenciaService(IEmpresaAssistenciaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<IEnumerable<EmpresaAssistencia>> GetAllAsync()
        {
            return await _empresaRepository.GetAllAsync();
        }

        public async Task<EmpresaAssistencia> GetByIdAsync(int id)
        {
            return await _empresaRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(EmpresaAssistencia empresa)
        {
            await _empresaRepository.AddAsync(empresa);
        }

        public async Task UpdateAsync(EmpresaAssistencia empresa)
        {
            await _empresaRepository.UpdateAsync(empresa);
        }

        public async Task DeleteAsync(int id)
        {
            await _empresaRepository.DeleteAsync(id);
        }
    }
}
