using DirtX.Infrastructure.Data.Models.Enums;

namespace DirtX.Models.Used
{
    public class UsedIndexViewModel
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Displacement { get; set; }
        public int Year { get; set; }
        public byte[] Image { get; set; }
        public Province Province { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Contact { get; set; }
    }
}
