using InScreeningApi.Data;
using InScreeningApi.Models;
using InScreeningApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InScreeningApi.Repository
{
    public class TriagemRepository : ITriagemRepository
    {
        private readonly dbContext dbContext;

        public TriagemRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Triagem> AddTriagem(Triagem triagem)
        {
            var result = await dbContext.Triagens.AddAsync(triagem);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Triagem> DeleteTriagem(int id)
        {
            var result = await dbContext.Triagens.FirstOrDefaultAsync(x => x.triagemId == id);
            if (result != null)
            {
                dbContext.Triagens.Remove(result);
                await dbContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task<Triagem> GetTriagem(int triId)
        {
            return await dbContext.Triagens.FirstOrDefaultAsync(
              x => x.triagemId == triId);
        }

        public async Task<IEnumerable<Triagem>> GetTriagem()
        {
            return await dbContext.Triagens.ToListAsync();
        }

        public async Task<Triagem> UpdateTriagem(Triagem triagem)
        {
            var result = await dbContext.Triagens.FirstOrDefaultAsync(x => x.triagemId == triagem.triagemId);

            if (result != null)
            {
                result.prioridade = triagem.prioridade;
                result.FuncionarioId = triagem.FuncionarioId;
                result.PacienteId = triagem.PacienteId;
                result.sintomas = triagem.sintomas;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
