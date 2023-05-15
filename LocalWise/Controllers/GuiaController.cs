using LocalWise.Data;
using LocalWise.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalWise.Controllers
{
    public class GuiaController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IEnumerable<Guia>> Index()
        //{    
        //    return (IEnumerable<Guia>)View(guia);
        //}
        //public IActionResult Detail()
        //{
        //    return View();
        //}
        //public IActionResult Register()
        //{
        //    return View();
        //}
    }
}
