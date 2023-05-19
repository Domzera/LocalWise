using Microsoft.AspNetCore.Mvc;

namespace LocalWise.Controllers
{
    public class RegisterLocalWiseManager : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
