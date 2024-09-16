using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InScreeningApi.Models
{
    public class Funcionario
    {

        [Key]
        public int funcionarioId { get; set; }

        [Column]
        public string Cpf { get; set; } = string.Empty;

        [Column]
        public string Email { get; set; } = string.Empty;

        [Column]
        public string Nome { get; set; } = string.Empty;
    }
}
