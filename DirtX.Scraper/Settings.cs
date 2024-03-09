using System.Text;

namespace DirtX.Scraper
{
    public static class Settings
    {
        public static void Config() 
        { 
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); 
        }

        public const string MxBaseUrl = "https://www.mobile.bg/obiavi/motori/krosov/ot-2006/do-2024/p-";
        public const string EnduroBaseUrl = "";

        public const string TitleNodes = "//a[@class='mmmL']";
        public const string PriceNodes = "//span[@class='price']";
        public const string DescriptionNodes = "//td[(contains(@colspan,'3') or contains(@colspan,'4')) and contains(@style,'padding-left:')]";
        public const string LinkNodes = "//a[@class='photoLinkL']";
    }
}
