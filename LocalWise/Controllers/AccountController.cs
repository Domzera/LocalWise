using CloudinaryDotNet.Actions;
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
                        var type = await _userManager.GetRolesAsync(user);
                        if (type[0] == UserRoles.Guia)
                        {
                            return RedirectToAction("index", "Guia");
                        }
                        if (type[0] == UserRoles.Turista)
                        {
                            return RedirectToAction("index", "Turista");
                        }
                        if (type[0] == UserRoles.GerenteLocal)
                        {
                            return RedirectToAction("index", "GerenteLocal");
                        }
                        if (type[0] == UserRoles.LocalWise)
                        {
                            return RedirectToAction("index", "LocalWise");
                        }
                        if (type[0] == UserRoles.Guia && type[0] == UserRoles.Turista)
                        {
                            return RedirectToAction("index", "Account");
                        }

                        /*
                        switch (type[0])
                        {
                            case UserRoles.Guia : 
                                return RedirectToAction("index", "Guia");
                                break;
                            case UserRoles.Turista: 
                                return RedirectToAction("index", "Turista");
                                break;
                            case UserRoles.GerenteLocal:
                                return RedirectToAction("index", "GerenteLocal");
                                break;
                            case UserRoles.LocalWise :
                                return RedirectToAction("index", "LocalWise");
                                break;
                            default:
                                return RedirectToAction("index", "Account");
                                break;
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
                    var role = await _roleManager.RoleExistsAsync(UserRoles.Turista);
                    if(!role) await _roleManager.CreateAsync(new IdentityRole(UserRoles.Turista));
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
