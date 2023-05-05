using LocalWise.Data;
using LocalWise.Interfaces;
using LocalWise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocalWise.Controllers
{
    public class GerenteLocalController : Controller
    {
        private readonly IGerenteLocalRepository _gerenteLocalRepository;

        public GerenteLocalController(IGerenteLocalRepository gerenteLocalRepository)
        {
            _gerenteLocalRepository = gerenteLocalRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail(int id)
        {
            /*  ---   IMPORTANTE   ---
             * Devemos colocar i Include(a => =a.Endereco) para conseguir chamar oendereco na 
             * tela Detail do GuiaS
             */
            GerenteLocal gerenteLocal = await _gerenteLocalRepository.GetByIdAsync(id);
            return View(gerenteLocal);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(GerenteLocal gerenteLocal)
        {
            if(!ModelState.IsValid)
            {
                return View(gerenteLocal);
            }
            _gerenteLocalRepository.Add(gerenteLocal);
            return RedirectToAction("Index");
        }
    }
}
