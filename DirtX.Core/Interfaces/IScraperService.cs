namespace DirtX.Core.Interfaces
{
    public interface IScraperService
    {
        Task<string> RunScraper();
        string GetScraperOutputFolder();
    }
}
