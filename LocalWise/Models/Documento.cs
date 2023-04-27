using System.ComponentModel.DataAnnotations.Schema;

namespace LocalWise.Models
{
    public class Documento
    {
        public int Id { get; set; }
        public string? Documentos { get; set; }
        public string? URL { get; set; }
        [ForeignKey("GerenteLocal")]
        public int? GerenteLocalId { get; set; }
        public GerenteLocal? GerenteLocal { get; set; }
    }
}
