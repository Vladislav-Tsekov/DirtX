using Microsoft.AspNetCore.Http;

namespace DirtX.Core.Validation
{
    public class FormFileConverter
    {
        public static byte[] ConvertToByteArray(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
