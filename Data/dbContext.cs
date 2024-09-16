using InScreeningApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InScreeningApi.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Triagem> Triagens { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
    }
}
