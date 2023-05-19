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
    }
}
