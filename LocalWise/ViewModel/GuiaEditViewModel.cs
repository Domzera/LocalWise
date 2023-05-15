namespace LocalWise.ViewModel
{
    public class GuiaEditViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string DataCadastro { get; set; }
        public IFormFile UrlPhoto { get; set; }
    }
}
