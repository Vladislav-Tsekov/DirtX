using DirtX.Web.Data;
using DirtX.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Web.Controllers
{
    public class TrailerController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        public TrailerController(ApplicationDbContext _context/*ILogger<HomeController> logger*/)
        {
            //_logger = logger;
            context = _context;
        }

        public async Task<IActionResult> Index()
        {
            var trailers = await context.Trailers.ToListAsync();

            if (trailers is null)
            {

            }

            if (!ModelState.IsValid)
            {

            }

            var model = new TrailerIndexViewModel() 
            { 
                
            };

            return View(model);
        }
    }
}
