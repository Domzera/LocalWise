using LocalWise.Models;
using Microsoft.AspNetCore.Identity;

namespace LocalWise.ViewModel
{
    public class RegisterLocalWiseManagerViewModel
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? senha { get; set; }
    }
}
