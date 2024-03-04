using DirtX.Web.Data;
using DirtX.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Index()
        {
            var mostExpensiveParts = context.Parts.OrderByDescending(p => p.Price).Take(5).ToList();

            return View(mostExpensiveParts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
