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
    }
}
