﻿using LocalWise.Models;

namespace LocalWise.ViewModel
{
    public class GuiaListaViewModel
    {
        public string Ativo { get; set; }
        public Pessoa Pessoa { get; set; }
        public IFormFile UrlPhoto { get; set; }
    }
}
