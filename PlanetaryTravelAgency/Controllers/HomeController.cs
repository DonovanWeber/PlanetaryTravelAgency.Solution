using Microsoft.AspNetCore.Mvc;

namespace PlanetaryTravelAgency.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}