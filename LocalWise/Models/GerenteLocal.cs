using System.ComponentModel.DataAnnotations.Schema;

namespace LocalWise.Models
{
    public class GerenteLocal
    {
        public int Id { get; set; }
        public string? RazaoSocial { get; set; }
        [ForeignKey("Endereco")]
        public int? EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }
        [ForeignKey("Pessoa")]
        public string? PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }
    }
}
