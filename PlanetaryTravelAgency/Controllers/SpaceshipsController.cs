using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlanetaryTravelAgency.Models;

namespace PlanetaryTravelAgency.Controllers
{
  public class SpaceshipsController : Controller 
  {
    private readonly PlanetaryTravelAgencyContext _db;

    public SpaceshipsController(PlanetaryTravelAgencyContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      // List<Planet> model = _db.Spaceships.ToList();
      return View(_db.Spaceships.ToList());
    }

    public ActionResult Create()
    {
      // ViewBag.SpaceshipId = new SelectList(_db.SpaceShips, "SpaceshipId", "Name");
      ViewBag.PlanetId = new SelectList(_db.Planets, "PlanetId", "Name");
      return View();
    }
    
    [HttpPost]
    public ActionResult Create(Spaceship spaceship, int PlanetId)
    {
      _db.Spaceships.Add(spaceship);
      _db.SaveChanges();
      if(PlanetId != 0)
      {
        _db.PlanetSpaceship.Add(new PlanetSpaceship() { PlanetId = PlanetId, SpaceshipId = spaceship.SpaceshipId});
        _db.SaveChanges();
      }
      ViewBag.PlanetId = new SelectList(_db.Planets, "PlanetId", "Name");
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisSpaceship = _db.Spaceships
          .Include(spaceship => spaceship.JoinEntities)
          .ThenInclude(join => join.Planet)
          .FirstOrDefault(spaceship => spaceship.SpaceshipId == id);
      return View(thisSpaceship);
    }

    public ActionResult Edit(int id)
    {
    var thisSpaceship = _db.Spaceships.FirstOrDefault(spaceship => spaceship.SpaceshipId == id);
    ViewBag.PlanetId = new SelectList(_db.Planets, "PlanetId", "Name");
    return View(thisSpaceship);
    }

    [HttpPost]
    public ActionResult Edit(Spaceship spaceship, int PlanetId)
    {
      _db.Entry(spaceship).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        var thisSpaceship = _db.Spaceships.FirstOrDefault(spaceship => spaceship.SpaceshipId == id);
        return View(thisSpaceship);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisSpaceship = _db.Spaceships.FirstOrDefault(spaceship => spaceship.SpaceshipId == id);
      _db.Remove(thisSpaceship);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddPlanet(int id)
    {
      var thisSpaceship = _db.Spaceships.FirstOrDefault(spaceship => spaceship.SpaceshipId == id);
      ViewBag.PlanetId = new SelectList(_db.Planets, "PlanetId", "Name");
      return View(thisSpaceship);
    }

    [HttpPost]
    public ActionResult AddPlanet(Spaceship spaceship, int PlanetId)
    {
      // var thisPlanet = _db.Planets.FirstOrDefault(planet => planet.PlanetId = PlanetId);
      // var thisSpaceship = _db.Spaceships
      //       .Include(spaceship => spaceship.JoinEntities);
      //       .ThenInclude(join => join.Planet);
      //       .FirstOrDefault(spaceship => spaceship.PlanetId = PlanetId);

      // if(thisPlanet.Contains(thisSpaceship))
      if(PlanetId != 0)
      {
        _db.PlanetSpaceship.Add(new PlanetSpaceship() {PlanetId = PlanetId, SpaceshipId = spaceship.SpaceshipId});
        _db.SaveChanges();
      }
        return RedirectToAction("Index");
    }

      [HttpPost]
      public ActionResult DeletePlanet(int joinId)
      {
        var joinEntry = _db.PlanetSpaceship.FirstOrDefault(entry => entry.PlanetSpaceshipId == joinId);
        _db.PlanetSpaceship.Remove(joinEntry);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
  }
}