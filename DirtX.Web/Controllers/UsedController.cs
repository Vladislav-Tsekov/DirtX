using Microsoft.AspNetCore.Mvc;

namespace DirtX.Controllers
{
    public class UsedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sell()
        {
            return View();
        }
    }
}
