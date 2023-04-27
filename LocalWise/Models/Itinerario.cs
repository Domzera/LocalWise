using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace LocalWise.Models
{
    public class Itinerario
    {
        public int Id { get; set; }
        public string? Valor { get; set; }
        public string? Transport { get; set; }
        [ForeignKey("Guia")]
        public int? GuiaId { get; set; }
        public Guia? Guia { get; set; }
    }
}
