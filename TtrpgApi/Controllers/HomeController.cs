using Microsoft.AspNetCore.Mvc;

namespace TtrpgApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
