using LocalWise.Data.Enum;
using LocalWise.Models;

namespace LocalWise.ViewModel
{
    public class RegisterGerenteLocalViewModel
    {
        public string? Id { get; set; }
        public string? RazaoSocial { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Cep { get; set; }
        public Estados Estado { get; set; }
        public string? DataCadastro { get; set; }
    }
}
