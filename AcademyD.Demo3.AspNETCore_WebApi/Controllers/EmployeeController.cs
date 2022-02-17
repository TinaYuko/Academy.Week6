using Microsoft.AspNetCore.Mvc;

namespace AcademyD.Demo3.AspNetCore_WebAPI.Controllers
{
    public class HomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
