using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InScreeningApi.Models
{
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }

        [Column("Estado")]
        public string Estado { get; set; } = string.Empty;

        [Column("Municipio")]
        public string Municipio { get; set; } = string.Empty;

        [Column("Logradouro")]
        public string Logradouro { get; set; } = string.Empty;

        [Column("Numero")]
        public string Numero { get; set; } = string.Empty;

        [Column("Complemento")]
        public string Complemento { get; set; } = string.Empty;

        [Column("Cep")]
        public string Cep { get; set; } = string.Empty;
 
    }
}
