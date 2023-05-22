using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LocalWise.Models;

namespace LocalWise.Controllers
{
    public class GerenteLocal
        : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
