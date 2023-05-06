using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalWise.Models
{
    public class Pessoa : IdentityUser
    {
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }
    }
}
