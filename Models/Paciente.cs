using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InScreeningApi.Models
{
    public class Paciente
    {

        [Key]
        public int pacienteId { get; set; }

        [Column("Nome")]

        public string Nome { get; set; } = string.Empty;

        [Column("Cpf")]
        public string Cpf { get; set; } = string.Empty;

        [Column("Email")]
        public string Email { get; set; } = string.Empty;

        [Column("Rg")]
        public string Rg { get; set; } = string.Empty;

        
        public SexoPaciente sexo { get; set; }

        public int EnderecoId { get; set; }
    

   

    }
}
