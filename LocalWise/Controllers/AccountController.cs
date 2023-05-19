using CloudinaryDotNet.Actions;
using LocalWise.Data;
using LocalWise.Data.Enum;
using LocalWise.Interfaces;
using LocalWise.Models;
using LocalWise.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

            //Aqui vai buscar todas as coisas do filtro - mas tem que colocar no lugar certo
            //var resultLinq = _context.PontoTuristicos
            //    .Where(w=> w.Endereco.Cidade == "Guara"
            //|| w.Itinerario.Transporte == Transporte.Onibus).ToList();

            var response = new LoginViewModel();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if (result.Succeeded)
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
                            return RedirectToAction("index", "RegisterLocalWiseManager");
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


        //===> Registro dos Gerentes do LocalWise <===
        //Tela de registro dos gerentes
        public IActionResult RegisterLocalWiseManager()
        {
            var response = new RegisterLocalWiseManagerViewModel();
            return View(response);
        }
        //Tela de Registro preenchida dos Gerentes
        [HttpPost]
        public async Task<IActionResult> RegisterLocalWiseManager(RegisterLocalWiseManagerViewModel registerLocalWiseManagerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerLocalWiseManagerViewModel);
            }
            var user = await _userManager.FindByEmailAsync(registerLocalWiseManagerViewModel.Email);
            if (user == null)
            {
                var newUser = new Pessoa()
                {
                    UserName = registerLocalWiseManagerViewModel.Nome,
                    Email = registerLocalWiseManagerViewModel.Email,
                    PasswordHash = registerLocalWiseManagerViewModel.Password
                };
                var newUserResponse = await _userManager.CreateAsync(newUser);
                if (newUserResponse.Succeeded)
                {
                    var role = await _roleManager.RoleExistsAsync(UserRoles.LocalWise);
                    if (!role) await _roleManager.CreateAsync(new IdentityRole(UserRoles.LocalWise));
                    await _userManager.AddToRoleAsync(newUser, UserRoles.LocalWise);
                }
                return RedirectToAction("Index", "RegisterLocalWiseManager");
            }
            return RedirectToAction("index", "Home");
        }


        //===> Controles do Turista <===
        //Tela de Registro do Turista
        public IActionResult TuristaRegister()
        {
            var response = new RegisterTuristaViewModel();
            return View(response);
        }
        //Tela de Registro peenchida do Turista
        [HttpPost]
        public async Task<IActionResult> TuristaRegister(RegisterTuristaViewModel registerTuristaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerTuristaViewModel);
            }
            var user = await _userManager.FindByEmailAsync(registerTuristaViewModel.Email);
            if (user == null)
            {
                var newUser = new Pessoa()
                {
                    Email = registerTuristaViewModel.Email,
                    UserName = registerTuristaViewModel.Nome
                };
                var newUserResponse = await _userManager.CreateAsync(newUser, registerTuristaViewModel.Senha);
                if (newUserResponse.Succeeded)
                {
                    //Criar Função aqui para preenchimento da Role!
                    var role = await _roleManager.RoleExistsAsync(UserRoles.Turista);
                    if (!role) await _roleManager.CreateAsync(new IdentityRole(UserRoles.Turista));
                    await _userManager.AddToRoleAsync(newUser, UserRoles.Turista);
                }
                return RedirectToAction("index", "Turista");
            }

            return RedirectToAction("Login", "Account");
        }
        //Tela de Edição do Turista
        [Authorize]
        public IActionResult TuristaEdit()
        {
            var response = new TuristaEditViewModel();
            return View(response);
        }
        //Tela de Edição do Turista preenchido
        [Authorize]
        public async Task<IActionResult> TuristaEdit(string id, TuristaEditViewModel TEViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Fail to edit");
                return View("TuristaEdit", TEViewModel);
            }
            //------Daqui para baixo
            var turista = await _userManager.FindByIdAsync(id);
            if (turista == null) return View("Error");
            var ETViewModel = new RegisterTuristaViewModel
            {
                Nome = turista.UserName,
                Email = turista.Email
            };
            return View(ETViewModel);
        }


        //===> Controles do Guia <===
        //Tela de Edição do Guia
        [Authorize]
        public IActionResult GuiaEdit()
        {
            var resonse = new GuiaEditViewModel();
            return View(resonse);
        }
        //Tela de Edição do Guia preenchida
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GuiaEdit(string id, GuiaEditViewModel GEViewModel)
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
                Email = guia.Email,

            };
            return View(EGViewModel);
        }
        //Tela de Registro do Guia
        public IActionResult GuiaRegister()
        {
            var response = new RegisterGuiaViewModel();
            return View(response);
        }
        //Tela de Registro do Guia preenchida
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


        //===> Controles do Gerente_Local <===
        //Tela de Edição do Gerente_Local
        [Authorize]
        public IActionResult GerenteLocalEdit()
        {
            var resonse = new GerenteLocalEditViewModel();
            return View(resonse);
        }
        //Tela de Edição do Gerente_Local preenchida
        //[HttpPost]
        //[Authorize]
        //public async Task<IActionResult> GerenteLocalEdit(int id)

        //COPIAR O EDIT DO TURISTA!!!!!!!

        //{
        //    if (id == null)
        //    {
        //        return View();
        //    }
        //    //-----Daqui para baixo
        //    var gLocal = await _context.GerenteLocals.FirstOrDefaultAsync(g => g.Id == id);
        //    if (await TryUpdateModelAsync<GerenteLocalEditViewModel>(gLocal, "",
        //        g => g.RazaoSocial,
        //        g => g.Logradouro,
        //        g => g.Numero,
        //        g => g.Bairro,
        //        g => g.Cidade,
        //        g => g.Cep,
        //        g => g.Estado
        //        ))
        //    {
        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction("index", "GerenteLocal");
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError("", "Unable to save changes!");
        //        }
        //    }
        //        return RedirectToAction("Index", "GerenteLocal");
        //}
        //Tela de Registro do Gerente_Local
        public IActionResult RegisterGerenteLocal()
        {
            var response = new RegisterGerenteLocalViewModel();
            return View(response);
        }
        //Tela de Registro do Gerente_Local preenchida
        [HttpPost]
        public async Task<IActionResult> RegisterGerenteLocal(RegisterGerenteLocalViewModel registerGerenteLocalViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerGerenteLocalViewModel);
            }
            var user = await _context.FindAsync<GerenteLocal>(registerGerenteLocalViewModel.RazaoSocial);
            if (user == null)
            {
                var newUser = new RegisterGerenteLocalViewModel()
                {
                    RazaoSocial = registerGerenteLocalViewModel.RazaoSocial
                };
                var newUser2 = new Endereco()
                {
                    Logradouro = registerGerenteLocalViewModel.Logradouro,
                    Numero = registerGerenteLocalViewModel.Numero,
                    Bairro = registerGerenteLocalViewModel.Bairro,
                    Cidade = registerGerenteLocalViewModel.Cidade,
                    Cep = registerGerenteLocalViewModel.Cep,
                    Estado = registerGerenteLocalViewModel.Estado,
                };
                return RedirectToAction("index", "GerenteLocal");
            }
            var user2 = await _userManager.GetUserAsync(User);
            if (user2 != null)
            {
                var senha = new Pessoa()
                {
                    Email = user2.Email,
                    DataCadastro = DateTime.Now
                };
                var senha1 = await _userManager.CreateAsync(senha, registerGerenteLocalViewModel.Password);
                if (senha1.Succeeded)
                {
                    //Criar Função aqui para preenchimento da Role!
                    var role = await _roleManager.RoleExistsAsync(UserRoles.GerenteLocal);
                    if (!role) await _roleManager.CreateAsync(new IdentityRole(UserRoles.GerenteLocal));
                    await _userManager.AddToRoleAsync(senha, UserRoles.GerenteLocal);
                }
            }

            return RedirectToAction("Login", "Account");
        }


        // ====>  Aqui é o controle dos LocalWiser´s e registros!  <====
        [HttpPost]
        public IActionResult LWRegisterManager()
        {
            var response = new LWRegisterManagerViewModel();
            return View(response);
        }
        public async Task<IActionResult> LWRegisterManager(LWRegisterManagerViewModel LWRMVM)
        {
            if (!ModelState.IsValid)
            {
                return View(null);//Arrumar
            }
            var user = await _userManager.FindByEmailAsync(LWRMVM.Email);
            if (user != null)
            {
                TempData["Error"] = "This email address is alread in use";
                return View(LWRMVM);
            }

            var newUser = new Pessoa()
            {
                UserName = LWRMVM.Nome,
                Email = LWRMVM.Email
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, LWRMVM.Senha);
            if(newUserResponse != null)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.LocalWise);
            }
            return View(LWRMVM);
        }
    }
}
