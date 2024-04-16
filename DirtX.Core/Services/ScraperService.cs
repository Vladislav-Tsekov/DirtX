using DirtX.Core.Interfaces;
using DirtX.Scraper;
using DirtX.Scraper.Data;
using DirtX.Scraper.Shared;

namespace DirtX.Core.Services
{
    public class ScraperService : IScraperService
    {
        private readonly ScraperDbContext context;
        private readonly ScraperSettings settings;

        public ScraperService(ScraperDbContext _context, ScraperSettings _settings)
        {
            context = _context;
            settings = _settings;
        }

        public async Task<string> RunScraper()
        {
            BaseScraper baseScraper = new(context, settings);
            return await baseScraper.Run();
        }

        public string GetScraperOutputFolder()
        {
            return settings.GetScraperOutputDirectory();
        }
    }
}
