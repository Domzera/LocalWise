﻿using LocalWise.Models;
using System.Security.Principal;

namespace LocalWise.ViewModel
{
    public class RegisterGuiaViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public IFormFile UrlPhoto { get; set; }
    }
}
