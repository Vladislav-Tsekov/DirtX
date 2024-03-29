using DirtX.Core.Models;
using DirtX.Infrastructure.Data;
using DirtX.Infrastructure.Data.Models.Trailers;
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

        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> Availability(int trailerId)
        {
            var trailer = await context.Trailers.FindAsync(trailerId);

            if (trailer == null)
            {
                return NotFound();
            }

            var rents = await context.TrailersRents
                .Where(r => r.TrailerId == trailerId)
                .ToListAsync();

            var model = new TrailerAvailabilityViewModel
            {
                TrailerId = trailerId,
                TrailerTitle = trailer.Title,
                Rents = rents
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Rent(TrailerRent model)
        {
            if (ModelState.IsValid)
            {
                var conflictRents = await context.TrailersRents
                    .Where(r => r.TrailerId == model.TrailerId &&
                                ((model.StartDate >= r.StartDate && model.StartDate <= r.ReturnDate) ||
                                 (model.ReturnDate >= r.StartDate && model.ReturnDate <= r.ReturnDate)))
                    .ToListAsync();

                if (conflictRents.Any())
                {
                    ModelState.AddModelError("", "The trailer is not available for the selected dates.");
                }
                else
                {
                    var rent = new TrailerRent
                    {
                        TrailerId = model.TrailerId,
                        UserId = model.UserId,
                        StartDate = model.StartDate,
                        ReturnDate = model.ReturnDate
                    };

                    context.TrailersRents.Add(rent);
                    await context.SaveChangesAsync();

                    return RedirectToAction("Index", "Home"); // Redirect to home or any other page
                }
            }

            return RedirectToAction("CheckAvailability", new { trailerId = model.TrailerId });
        }
    }
}