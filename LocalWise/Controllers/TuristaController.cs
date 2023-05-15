using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalWise.Controllers
{
    public class TuristaController : Controller
    {
        //private readonly IGuia
        //[Authorize]
        //public async Task<IActionResult> Edit(int id)
        //{

        //}
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult Detail()
        //{
        //    return View();
        //}
    }
}
