using Microsoft.AspNetCore.Mvc;

namespace DirtX.Web.Controllers
{
    public class ConverterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Convert(int conversionType, double inputValue)
        {
            double result = 0;
            string resultMessage = "";

            switch (conversionType)
            {
                case 1:
                    result = inputValue * 2.54;
                    resultMessage = $"{inputValue} inches is equal to {result} centimeters.";
                    break;
                case 2: 
                    result = inputValue / 2.54;
                    resultMessage = $"{inputValue} centimeters is equal to {result} inches.";
                    break;
                case 3: 
                    result = inputValue * 0.453592; 
                    resultMessage = $"{inputValue} pounds is equal to {result} kilograms.";
                    break;
                case 4: 
                    result = inputValue / 0.453592; 
                    resultMessage = $"{inputValue} kilograms is equal to {result} pounds.";
                    break;
                case 5: 
                    result = inputValue * 1.60934; 
                    resultMessage = $"{inputValue} miles per hour is equal to {result} kilometers per hour.";
                    break;
                case 6:
                    result = inputValue / 1.60934;
                    resultMessage = $"{inputValue} kilometers per hour is equal to {result} miles per hour.";
                    break;
                default:
                    ViewBag.ErrorMessage = "Invalid conversion type.";
                    return View("Index");
            }

            ViewBag.Result = resultMessage;
            return View("Index");
        }
    }
}
