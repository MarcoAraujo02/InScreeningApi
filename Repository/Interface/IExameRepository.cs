using InScreeningApi.Models;
using System.Collections;

namespace InScreeningApi.Repository.Interface
{
    public interface IExameRepository
    {
        Task<IEnumerable> GetExame();

    }
}
