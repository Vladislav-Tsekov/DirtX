using Microsoft.AspNetCore.Mvc;

namespace DirtX.Web.Controllers
{
    public class BaseController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return PartialView("Error400");
            }
            else if (statusCode == 404)
            {
                return PartialView("Error404");
            }

            return PartialView("Error500");
        }
    }
}
