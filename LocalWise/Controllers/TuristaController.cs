using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalWise.Controllers
{
    public class TuristaController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
