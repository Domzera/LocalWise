using LocalWise.Data;
using LocalWise.Models;
using LocalWise.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LocalWise.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Pessoa> _userManager;
        private readonly SignInManager<Pessoa> _signInManager;
        private readonly LWDbContext _context;

        public AccountController(
            UserManager<Pessoa> userManager,
            SignInManager<Pessoa> signInManager,
            LWDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if(!ModelState.IsValid) {
                return View(loginViewModel);
            } 
            var user =await _userManager.FindByEmailAsync(loginViewModel.Email);
            if(user !=null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if(result.Succeeded)
                    {
                        //fazer o teste para descobrir o que o logado é( Turista ou Guia)
                        var type = await _context.
                        if (type=="Guia")
                        {
                            return RedirectToAction("index", "Guia");
                        }
                        if (type == "Turista")
                        {
                            return RedirectToAction("index", "Turista");
                        }
                        if (type == "Guia" && type=="Turista")
                        {
                            return RedirectToAction("index", "Account");
                        }
                    }
                }
            }
        }
    }
}
