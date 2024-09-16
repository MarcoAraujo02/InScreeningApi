using InScreeningApi.Models;

namespace InScreeningApi.Repository.Interface
{
    public interface ITriagemRepository
    {
        Task<IEnumerable<Triagem>> GetTriagem();
        Task<Triagem> GetTriagem(int id);
        Task<Triagem> AddTriagem(Triagem triagem);
        Task<Triagem> UpdateTriagem(Triagem triagem);
        Task<Triagem> DeleteTriagem(int id);
    }
}
