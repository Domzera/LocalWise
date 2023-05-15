using CloudinaryDotNet.Actions;
using LocalWise.Data;
using LocalWise.Interfaces;
using LocalWise.Models;
using LocalWise.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LocalWise.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Pessoa> _userManager;
        private readonly SignInManager<Pessoa> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IPhotoService _photoService;
        private readonly LWDbContext _context;

        public AccountController(
            UserManager<Pessoa> userManager,
            SignInManager<Pessoa> signInManager,
            RoleManager<IdentityRole> roleManager,
            IPhotoService photoService,
            LWDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _photoService = photoService;
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
                    }
                }
                
            }
            return RedirectToAction("index", "Home");
        }

        //Tem que ter autorização para seguir!
        [Authorize]

        //Controles do Turista
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
                    //Criar Função aqui para preenchimento da Role!
                    var role = await _roleManager.RoleExistsAsync(UserRoles.Turista);
                    if(!role) await _roleManager.CreateAsync(new IdentityRole(UserRoles.Turista));
                    await _userManager.AddToRoleAsync(newUser,UserRoles.Turista);
                }
                return RedirectToAction("index", "Turista");
            }

            return RedirectToAction("Login","Account");
        }

        //Controles do Guia
        public IActionResult GuiaEdit()
        {
            var resonse = new GuiaEditViewModel();
            return View(resonse);
        }
        [HttpPost]
        public async Task<IActionResult> GuiaEdit(string id,GuiaEditViewModel GEViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Fail to edit");
                return View("GuiaEdit", GEViewModel);
            }
            //-----Daqui para baixo
            var guia = await _userManager.FindByIdAsync(id);
            if (guia == null) return View("Error");
            var EGViewModel = new GuiaEditViewModel
            {
                Name = guia.UserName,
                Email=guia.Email,
                
            };
            return View(EGViewModel);
        }

        public IActionResult GuiaRegister()
        {
            var response = new RegisterGuiaViewModel();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> GuiaRegister(RegisterGuiaViewModel registerGuiaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerGuiaViewModel);
            }
            var user = await _userManager.FindByEmailAsync(registerGuiaViewModel.Email);
            if (user == null)
            {
                var newUser = new Pessoa()
                {
                    Email = registerGuiaViewModel.Email,
                    UserName = registerGuiaViewModel.Name,
                    DataCadastro = DateTime.Now
                };
                var newUserResponse = await _userManager.CreateAsync(newUser, registerGuiaViewModel.Senha);
                if (newUserResponse.Succeeded)
                {
                    //Criar Função aqui para preenchimento da Role!
                    var role = await _roleManager.RoleExistsAsync(UserRoles.Guia);
                    if (!role) await _roleManager.CreateAsync(new IdentityRole(UserRoles.Guia));
                    await _userManager.AddToRoleAsync(newUser, UserRoles.Guia);
                }
                var foto = await _photoService.AddPhotoAsync(registerGuiaViewModel.UrlPhoto);
                var guia = new Guia()
                {
                    UrlPhoto = registerGuiaViewModel.UrlPhoto.ToString()
                };
                return RedirectToAction("index", "Guia");
            }

            return RedirectToAction("Login", "Account");
        }
    }
}
