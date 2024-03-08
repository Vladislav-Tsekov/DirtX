using DirtX.Web.Data;
using DirtX.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DirtX.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext _context/*ILogger<HomeController> logger*/)
        {
            //_logger = logger;
            context = _context;
        }

        //TODO - MODELSTATE VALIDATION EVERYWHERE!
        //TODO - DROPDOWN JS - SELECT 2 LIBRARY
        public IActionResult Index()
        {
            var mostExpensiveParts = context.Parts.OrderByDescending(p => p.Price).Take(5).ToList();

            if (!ModelState.IsValid)
            {
                return Error();
            }

            return View(mostExpensiveParts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
