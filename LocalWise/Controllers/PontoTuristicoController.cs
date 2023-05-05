using LocalWise.Interfaces;
using LocalWise.Models;
using LocalWise.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LocalWise.Controllers
{
    public class PontoTuristicoController : Controller
    {
        private readonly IPontoTuristicoRepository _pontoTuristicoRepository;
        private readonly IPhotoService _photoService;
        private readonly IPhotoRepository _photoRepository;
        public PontoTuristicoController(IPontoTuristicoRepository pontoTuristicoRepository,IPhotoService photoService,IPhotoRepository photoRepository)
        {
            _pontoTuristicoRepository = pontoTuristicoRepository;
            _photoService = photoService;
            _photoRepository = photoRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail(int id)
        {
            PontoTuristico pontoTuristico = await _pontoTuristicoRepository.GetByIdAsync(id);
            return View(pontoTuristico);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePontoTuristicoViewModel PontoTVM)
        {
            if(ModelState.IsValid)
            {
                if (PontoTVM.Image1 == null) { var result1 = await _photoService.AddPhotoAsync(PontoTVM.Image1); }
                if (PontoTVM.Image2 == null) { var result1 = await _photoService.AddPhotoAsync(PontoTVM.Image2); }
                if (PontoTVM.Image3 == null) { var result1 = await _photoService.AddPhotoAsync(PontoTVM.Image3); }
                if (PontoTVM.Image4 == null) { var result1 = await _photoService.AddPhotoAsync(PontoTVM.Image4); }
                if (PontoTVM.Image5 == null) { var result1 = await _photoService.AddPhotoAsync(PontoTVM.Image5); }

                var pontoTuristico = new PontoTuristico
                {
                    Nome=PontoTVM.Nome,
                    Detalhes=PontoTVM.Detalhes,
                    Valor=PontoTVM.Valor,
                    Endereco=new Endereco
                    {
                        Logradouro=PontoTVM.Endereco.Logradouro,
                        Numero=PontoTVM.Endereco.Numero,
                        Bairro= PontoTVM.Endereco.Bairro,
                        Cidade= PontoTVM.Endereco.Cidade,
                        Cep= PontoTVM.Endereco.Cep,
                        Estado= PontoTVM.Endereco.Estado,
                    }
                };
            }
            else
            {
                ModelState.AddModelError("", "Foto upload falhou");
            }
            return View(PontoTVM);
        }
    }
}
