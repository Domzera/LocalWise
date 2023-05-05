using LocalWise.Data;
using LocalWise.Interfaces;
using LocalWise.Models;
using LocalWise.Repository;
using LocalWise.Services;
using LocalWise.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace LocalWise.Controllers
{
    public class GuiaController : Controller
    {
        private readonly IGuiaRepository _guiaRepository;
        private readonly IPhotoService _photoService;

        public GuiaController(IGuiaRepository guiaRepository,IPhotoService photoService)
        {
            _guiaRepository = guiaRepository;
            _photoService = photoService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(int id) {
            /*  ---   IMPORTANTE   ---
             * Devemos colocar i Include(a => =a.Agenda) para conseguir chamar os horarios de trabalho na 
             * tela Detail do GuiaS
             */
            Guia guia = await _guiaRepository.GetByIdAsync(id);
            return View(guia);
        }
        public IActionResult Create()
        {
            return View();
        }

        //Aqui começa o cadastro do Guia onde tem o Upload da foto
        [HttpPost]
        public async Task<IActionResult> Create(CreateGuiaViewModel guiaVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(guiaVM.UrlPhoto);

                var guia = new Guia
                {
                    //Aqui dentro temos que criar uma nova Pessoa para poder entrar com os dados
                    Pessoa = new Pessoa
                    {
                        Nome=guiaVM.Pessoa.Nome,
                        Email=guiaVM.Pessoa.Email,
                        Password=guiaVM.Pessoa.Password
                    },
                    //Aqui coloca os dados normalmente
                    UrlPhoto = result.Url.ToString()
                };
                _guiaRepository.Add(guia);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Falha no upload da foto!");
            }
            return View(guiaVM);
        }

        public async Task<IActionResult> GuiaLista()
        {
            IEnumerable<Guia> guias = await _guiaRepository.GetAll();
            return View(guias);
            
        }
    }
}
