using InScreeningApi.Models;

namespace InScreeningApi.Repository.Interface
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> GetPacientes();
        Task<IEnumerable<Endereco>> GetEndereco();
        Task<Paciente> GetPaciente(int id);
        Task<Paciente> AddPaciente(Paciente paciente);
        Task<Paciente> UpdatePaciente(Paciente paciente);
        Task<Endereco> AddEndereco(Endereco endereco);
        Task<Paciente> DeletePaciente(int id);
    }
}
