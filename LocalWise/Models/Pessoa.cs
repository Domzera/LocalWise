using System.ComponentModel.DataAnnotations;

namespace LocalWise.Models
{
    public class Pessoa
    {
        [Key]
        public string? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }
    }
}
