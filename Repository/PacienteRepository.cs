using InScreeningApi.Data;
using InScreeningApi.Models;
using InScreeningApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InScreeningApi.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly dbContext dbContext;

        public PacienteRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Paciente> AddPaciente(Paciente paciente)
        {
            var result = await dbContext.Pacientes.AddAsync(paciente);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Paciente> DeletePaciente(int id)
        {
            var result = await dbContext.Pacientes.FirstOrDefaultAsync(x => x.pacienteId == id);
            if (result != null)
            {
                dbContext.Pacientes.Remove(result);
                await dbContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task<Paciente> UpdatePaciente(Paciente paciente)
        {
            var result = await dbContext.Pacientes.FirstOrDefaultAsync(x => x.pacienteId == paciente.pacienteId);

            if (result != null)
            {
                result.Email = paciente.Email;
                result.sexo = paciente.sexo;
                result.Cpf = paciente.Cpf;
                result.Rg = paciente.Rg;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Paciente>> GetPacientes()
        {
            return await dbContext.Pacientes.ToListAsync();
        }

        public async Task<Paciente> GetPaciente(int id)
        {
            return await dbContext.Pacientes.FirstOrDefaultAsync(
                x => x.pacienteId == id);
        }

        public async Task<Endereco> AddEndereco(Endereco endereco)
        {
            var result = await dbContext.Endereco.AddAsync(endereco);
            await dbContext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<IEnumerable<Endereco>> GetEndereco()
        {
            return await dbContext.Endereco.ToListAsync();
        }
    }
}
