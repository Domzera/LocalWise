using LocalWise.Data;
using LocalWise.Interfaces;
using LocalWise.Models;
using LocalWise.Repository;
using LocalWise.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocalWise.Controllers
{
    public class TuristaController : Controller
    {
        private readonly UserManager<Pessoa> _pessoaManager;
        private readonly SignInManager<Pessoa> _signInManager;
        private readonly LWDbContext _LWDbContext;
        private readonly ITuristaRepository _turistaRepository;

        public TuristaController(
            ITuristaRepository turistaRepository,
            UserManager<Pessoa> userManager,
            SignInManager<Pessoa> signInManager,
            LWDbContext context)
        {
            _turistaRepository = turistaRepository;
        }
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lTViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(lTViewModel);
            }
            var user = await _pessoaManager.FindByEmailAsync(lTViewModel.Email);
            if(user!= null)
            {
                var passwordCheck = await _pessoaManager.CheckPasswordAsync(user, lTViewModel.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, lTViewModel.Password, false,false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("index", "Turista");
                    }
                }
                //Aqui tem que trocar pelo ceto
                TempData["Error"] = "Usuario ou senhaerrados. Tente novamente";
                return View(lTViewModel);
            }
            //Aqui tem que trocar pelo ceto
            TempData["Error"] = "Usuario ou senhaerrados. Tente novamente";
            return View(lTViewModel);
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail(int id) {

            Turista turista = await _turistaRepository.GetByIdAsync(id);
            return View(turista);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Turista turista)
        {
            if (!ModelState.IsValid)
            {
                return View(turista);
            }
            _turistaRepository.Add(turista);
            return RedirectToAction("Index");
        }
    }
}
