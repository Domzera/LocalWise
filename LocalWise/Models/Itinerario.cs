using LocalWise.Data.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace LocalWise.Models
{
    public class Itinerario
    {
        public int Id { get; set; }
        public string? Valor { get; set; }
        public Transporte Transporte { get; set; }
        public TipoPasseio TipoPasseio { get; set; }//Novo campo a ser adicionado
        [ForeignKey("Guia")]
        public int? GuiaId { get; set; }
        public Guia? Guia { get; set; }
    }
}
