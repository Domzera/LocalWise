using LocalWise.Models;
using System.ComponentModel.DataAnnotations;

namespace LocalWise.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name ="Email")]
        [Required(ErrorMessage ="É nescessário um Email!")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
