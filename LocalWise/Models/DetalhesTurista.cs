using System.ComponentModel.DataAnnotations.Schema;

namespace LocalWise.Models
{
    public class DetalhesTurista
    {
        public int Id { get; set; }
        public string? ValorPago { get; set; }
        [ForeignKey("DetalheGuia")]
        public int? DetalheGuiaId { get; set; }
        public DetalheGuia? DetalheGuia { get; set; }
        [ForeignKey("Turista")]
        public int? TuristaId { get; set; }
        public Turista? Turista { get; set; }
    }
}
