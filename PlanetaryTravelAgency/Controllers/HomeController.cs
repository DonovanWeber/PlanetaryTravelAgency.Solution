using Microsoft.AspNetCore.Mvc;
using PlanetaryTravelAgency.Models;

namespace PlanetaryTravelAgency.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public IActionResult Index()
      {
        return View();
      }

      // public IActionResult Photo()
      // {
      //   var randomPhoto = Planet.GetPlanets("I4TdB92OHOGDBmWf6FesyTLJM8MrW7paWnKLHpMi");
      //   return View( randomPhoto);
      // }
    }
}