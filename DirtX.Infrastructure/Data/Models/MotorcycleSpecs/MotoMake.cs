namespace DirtX.Infrastructure.Data.Models.MotorcycleSpecs
{
    public class MotoMake
    {
        public int Id { get; set; }
        public string Make { get; set; }

        public bool IsModelValid(MotoModel model)
        {
            if (Make == "Yamaha" && model.Model != "YZ-F")
            {
                return false;
            }

            return true;
        }
    }
}
