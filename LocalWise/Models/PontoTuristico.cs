using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalWise.Models
{
    public class PontoTuristico
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Detalhes { get; set; }
        public string? Ativo { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }
        public string? Valor { get; set; }
        [ForeignKey("Endereco")]
        public int? EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }
        [ForeignKey("GerenteLocal")]
        public int? GerenteLocalId { get; set; }
        public GerenteLocal? GerenteLocal { get; set; }
        [ForeignKey("Guia")]
        public int? GuiaId { get; set; }
        public Guia? Guia { get; set; }
        [ForeignKey("Itinerario")]
        public int? ItinerarioId { get; set; }
        public Itinerario? Itinerario { get; set; }

    }
}
