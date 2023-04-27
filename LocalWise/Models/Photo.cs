using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalWise.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public string? Url { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }
        [ForeignKey("PontoTuristico")]
        public int? PontoTuristicoId { get; set; }
        public PontoTuristico? PontoTuristico { get; set; }
    }
}
