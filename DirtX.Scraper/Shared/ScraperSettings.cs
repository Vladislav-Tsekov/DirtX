﻿using DirtX.Scraper.Data;
using DirtX.Scraper.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace DirtX.Scraper.Shared
{
    public class ScraperSettings
    {
        private readonly ScraperDbContext context;

        public ScraperSettings(ScraperDbContext _context)
        {
            context = _context;
        }

        public string GetScraperOutputDirectory() 
        {
            string parentDir = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            return Path.Combine(parentDir, @"DirtX.Scraper\Output");
        }

        public DateTime GetLastRunDateAsync()
        {
            ScraperInfo scraperInfo = context.ScraperInfo.FirstOrDefault();

            if (scraperInfo is null)
            {
                return DateTime.MinValue;
            }

            return scraperInfo.LastRunDate;
        }

        public void UpdateLastRunDateAsync()
        {
            ScraperInfo scraperInfo = context.ScraperInfo.FirstOrDefault();

            if (scraperInfo is null)
            {
                scraperInfo = new ScraperInfo();
                context.ScraperInfo.Add(scraperInfo);
            }
            else
            {
                context.ScraperInfo.RemoveRange(context.ScraperInfo);
                scraperInfo.LastRunDate = DateTime.Now;
                context.ScraperInfo.Add(scraperInfo);
            }

            context.SaveChanges();
        }

        public void Config()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
    }
}
