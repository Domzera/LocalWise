using LocalWise.Data.Enum;

namespace LocalWise.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Cep { get; set; }
        public Estados Estado { get; set; }
    }
}
