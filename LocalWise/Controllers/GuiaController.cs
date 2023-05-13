using LocalWise.Data;
using LocalWise.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocalWise.Controllers
{
    public class GuiaController : Controller
    {
        private readonly LWDbContext _lWDbContext;
        public GuiaController(LWDbContext context) {
        
            _lWDbContext = context;
        }
        public async Task<IEnumerable<Guia>> Index()
        {
            IEnumerable<Guia> guia = _lWDbContext.Guias.ToList();
            return (IEnumerable<Guia>)View(guia);
        }
        public IActionResult Detail()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
