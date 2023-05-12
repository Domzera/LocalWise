using System.ComponentModel.DataAnnotations.Schema;

namespace LocalWise.Models
{
    public class Guia     {
        public int Id { get; set; }
        public string? UrlPhoto { get; set; }
        public string? Ativo { get; set; }
        [ForeignKey("Pessoa")]
        public string? PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }
        [ForeignKey("GerenteLocal")]
        public int? GerenteLocalId { get; set; }
        public GerenteLocal? GerenteLocal { get; set; }
        [ForeignKey("Agenda")]
        public int? AgendaId { get; set; }
        public Agenda? Agenda { get; set; }
    }
}
