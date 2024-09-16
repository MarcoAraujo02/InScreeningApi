using InScreeningApi.Data;
using InScreeningApi.Models;
using InScreeningApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InScreeningApi.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {

        private readonly dbContext dbContext;

        public FuncionarioRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Funcionario> AddFuncionario(Funcionario funcionario)
        {
            var result = await dbContext.Funcionario.AddAsync(funcionario);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Funcionario> DeleteFuncionario(int id)
        {
            var result = await dbContext.Funcionario.FirstOrDefaultAsync(x => x.funcionarioId == id);
            if (result != null)
            {
                dbContext.Funcionario.Remove(result);
                await dbContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task<Funcionario> GetFuncionario(int funcid)
        {
            return await dbContext.Funcionario.FirstOrDefaultAsync(x => x.funcionarioId == funcid);
        }

        public async Task<IEnumerable<Funcionario>> GetFuncionario()
        {
            return await dbContext.Funcionario.ToListAsync();
        }

        public async Task<Funcionario> UpdateFuncionario(Funcionario funcionario)
        {
            var result = await dbContext.Funcionario.FirstOrDefaultAsync(x => x.funcionarioId == funcionario.funcionarioId);

            if(result != null)
            {
                result.funcionarioId = funcionario.funcionarioId;
                result.Nome = funcionario.Nome;
                result.Email = funcionario.Email;
                result.Cpf = funcionario.Cpf;

                await dbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }


    }
}
