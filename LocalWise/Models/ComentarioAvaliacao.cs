using System.ComponentModel.DataAnnotations.Schema;

namespace LocalWise.Models
{
    public class ComentarioAvaliacao
    {
        public int Id { get; set; }
        public string? ComentGuia { get; set; }
        public int AvalGuia { get; set; }
        public string? ComentItinerario { get; set; }
        public int AvalItinerario { get; set; }
        [ForeignKey("DetalheTurista")]
        public int? DetalheTuristaId { get; set; }
        public DetalhesTurista? DetalheTurista { get; set; }
    }
}
