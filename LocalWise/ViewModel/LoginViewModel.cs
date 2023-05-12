using System.ComponentModel.DataAnnotations;

namespace LocalWise.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name ="Email")]
        [Required(ErrorMessage ="É nescessário um Email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha invalida!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
