using System.ComponentModel.DataAnnotations.Schema;

namespace LocalWise.Models
{
    public class Turista
    {
        public int Id { get; set; }
        [ForeignKey("Pessoa")]
        public string? PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }
    }
}
