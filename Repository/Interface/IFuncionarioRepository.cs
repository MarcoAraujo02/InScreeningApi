using InScreeningApi.Models;

namespace InScreeningApi.Repository.Interface
{
    public interface IFuncionarioRepository
    {
        Task<IEnumerable<Funcionario>> GetFuncionario();
        Task<Funcionario> GetFuncionario(int id);
        Task<Funcionario> AddFuncionario(Funcionario funcionario);
        Task<Funcionario> UpdateFuncionario(Funcionario funcionario);
        Task<Funcionario> DeleteFuncionario(int id);
    }
}
