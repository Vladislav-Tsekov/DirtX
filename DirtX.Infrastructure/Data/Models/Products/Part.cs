using DirtX.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.ProductModels
{
    public class Part : Product
    {
        [Required]
        public PartType Type { get; set; }

        public List<PartProperty> PartProperties { get; set; }
        public List<MotorcyclePart> MotorcycleParts { get; set; }

        //https://i.ibb.co/tc2m4jh/Part-Brake-Pads.jpg
        //https://i.ibb.co/vqg672F/Part-Air-Filter.jpg
        //https://i.ibb.co/9tCHFWY/Part-Chain.jpg
        //https://i.ibb.co/9qGztRG/Part-Clutch-Plates.jpg
        //https://i.ibb.co/y0KwgV5/Part-Clutch-Kit.jpg
        //https://i.ibb.co/1RXqkVy/Part-Engine-Cover.png
        //https://i.ibb.co/m6fQKSx/Part-Forged-Piston.jpg
        //https://i.ibb.co/yyZK9tT/Part-Fork-Springs.jpg
        //https://i.ibb.co/7jy1dvG/Part-Fork-Seals.jpg
        //https://i.ibb.co/DG6HpM4/Part-Front-Brake-Disc.jpg
        //https://i.ibb.co/9pKtqn6/Part-Front-Sprocket.jpg
        //https://i.ibb.co/s1YdYwt/Part-Fuel-Filter-Tank.jpg
        //https://i.ibb.co/dmkcV30/Part-Fuel-Injector.jpg
        //https://i.ibb.co/LnW1Y4k/Part-Fuel-Pump.jpg
        //https://i.ibb.co/fG9XLdn/Part-Intake-Valves.jpg
        //https://i.ibb.co/jTnS3W0/Part-High-Comp-Piston.jpg
        //https://i.ibb.co/LtFwYZ3/Part-KYB-Shock.jpg
        //https://i.ibb.co/kG1KnVN/Part-Oil-Filter.jpg
        //https://i.ibb.co/V2qj6c0/Part-Oil-Filter-Cap.jpg
        //https://i.ibb.co/BNPMF26/Part-Rear-Brake-Disc.jpg
        //https://i.ibb.co/xGz2dVn/Part-Rear-Sprocket.png
        //https://i.ibb.co/LRQphRW/Part-Shock-Absorber.jpg
        //https://i.ibb.co/VCWrYtY/Part-Steering-Bearings.jpg
        //https://i.ibb.co/Yj4MJ6r/Part-Top-End-Gasket.jpg
        //https://i.ibb.co/ZHQ36hf/Part-Water-Pump-Cover.jpg
    }
}
