using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InScreeningApi.Models
{
    public class Triagem
    {

        [Key]
        public int triagemId { get; set; }


        [Column("Sintomas")]
        public string sintomas { get; set; } = string.Empty;

        [Column("DataInicio")]
        public DateTime dataInicio { get; set; } = System.DateTime.Now;

        [Column("Prioridade")]
        public Prioridade prioridade { get; set; }

        public int PacienteId { get; set; }

        public int FuncionarioId { get; set; }



    }
}
