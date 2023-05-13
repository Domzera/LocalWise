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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly LWDbContext _context;

        public AccountController(
            UserManager<Pessoa> userManager,
            SignInManager<Pessoa> signInManager,
            RoleManager<IdentityRole> roleManager,
            LWDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
            if(user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if(result.Succeeded)
                    {
                        //fazer o teste para descobrir o que o logado é( Turista ou Guia)
                        //var type = await _context.Roles.Where(user.Email==IdentityUserRole<>);
                        var type = _context.Pessoas.FirstOrDefault(i=>i.Email==user.Email);
                        var role = _context.UserRoles.FirstOrDefault(r => r.UserId == user.Id).ToString;
                        /*
                        if (role=="Guia")
                        {
                            return RedirectToAction("index", "Guia");
                        }
                        if (role == "Turista")
                        {
                            return RedirectToAction("index", "Turista");
                        }
                        if (role == "Guia" && type=="Turista")
                        {
                            return RedirectToAction("index", "Account");
                        }*/
                        
                    }
                }
                
            }
            return RedirectToAction("index", "Home");
        }
        
        public IActionResult TuristaRegister()
        {
            var response = new RegisterTuristaViewModel();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> TuristaRegister(RegisterTuristaViewModel registerTuristaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerTuristaViewModel);
            }
            var user = await _userManager.FindByEmailAsync(registerTuristaViewModel.Email);
            if(user == null)
            {
                var newUser = new Pessoa()
                {
                    Email = registerTuristaViewModel.Email,
                    UserName = registerTuristaViewModel.Nome
                };
                var newUserResponse = await _userManager.CreateAsync(newUser, registerTuristaViewModel.Senha);
                if(newUserResponse.Succeeded)
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Turista));
                    await _userManager.AddToRoleAsync(newUser,UserRoles.Turista);
                }
                return RedirectToAction("index", "Turista");
            }

            return RedirectToAction("Login","Account");
        }

        [HttpPost]
        public IActionResult Register()
        {
            return View();
        }
    }
}
