using DirtX.Core.Models;
using DirtX.Infrastructure.Data;
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

            if (trailers == null || trailers.Count == 0)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {

            }

            var model = trailers.Select(trailer => new TrailerIndexViewModel
            {
                Id = trailer.Id,
                Title = trailer.Title,
                CostPerDay = trailer.CostPerDay,
                Capacity = trailer.Capacity,
                MaximumLoad = trailer.MaximumLoad,
                IsAvailable = trailer.IsAvailable,
                ImageUrl = trailer.ImageUrl
            }).ToList();

            return View(model);
        }

        //public IActionResult CheckAvailability(int trailerId)
        //{
        //    return RedirectToAction("Availability", new { trailerId = trailerId });
        //}

        //public IActionResult Availability(int trailerId)
        //{
        //    return View();
        //}
    }
}
