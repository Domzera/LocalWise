using LocalWise.Data;
using LocalWise.Interfaces;
using LocalWise.Models;
using LocalWise.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocalWise.Controllers
{
    public class TuristaController : Controller
    {
        private readonly ITuristaRepository _turistaRepository;

        public TuristaController(ITuristaRepository turistaRepository)
        {
            _turistaRepository = turistaRepository;
        }
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
        public async Task<IActionResult> Create(Turista turista)
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
