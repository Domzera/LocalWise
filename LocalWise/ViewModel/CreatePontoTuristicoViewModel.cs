using LocalWise.Models;

namespace LocalWise.ViewModel
{
    public class CreatePontoTuristicoViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Detalhes { get; set; }
        public string Ativo { get; set; }
        public string DataCadastro { get; set; }
        public string Valor { get; set; }
        public Endereco Endereco { get; set; }
        public IFormFile Image1 { get; set; }
        public IFormFile Image2 { get; set; }
        public IFormFile Image3 { get; set; }
        public IFormFile Image4 { get; set; }
        public IFormFile Image5 { get; set; }
    }
}
