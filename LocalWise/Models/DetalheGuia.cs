using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalWise.Models
{
    public class DetalheGuia
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataRealizado { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataPrevista { get; set; }
        public string? Valor { get; set; }
        public string? Informacoes { get; set; }
        public string? ValorItinerario { get; set; }
        public string? ValorRecebido { get; set; }
        [ForeignKey("Guia")]
        public int? GuiaId { get; set; }
        public Guia? Guia { get; set; }
        [ForeignKey("Itinerario")]
        public int? ItinerarioId { get; set; }
        public Itinerario? Itinerario { get; set; }
    }
}
