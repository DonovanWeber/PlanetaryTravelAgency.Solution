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
      return View(_db.Spaceships.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.PlanetId = new SelectList(_db.Planets, "PlanetId", "Name");
      return View();
    }

     public ActionResult Edit(int id)
    {
      var thisSpaceship = _db.Spaceships.FirstOrDefault(spaceship => spaceship.SpaceshipId == id);
      ViewBag.PlanetId = new SelectList(_db.Planets, "PlanetId", "Name");
      return View(thisSpaceship);
    }

    [HttpPost]
    public ActionResult Create(Spaceship spaceship, int PlanetId)
    {
      _db.Spaceships.Add(spaceship);
      _db.SaveChanges();
      if(PlanetId != 0)
      {
        _db.PlanetSpaceships.Add(new PlanetSpaceship() { PlanetId = PlanetId, SpaceshipId = spaceship.SpaceshipId});
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

    [HttpPost]
    public ActionResult Edit(Spaceship spaceship, int PlanetId)
    {
      var thisPlanet = _db.Planets
          .Include(spaceship => spaceship.JoinEntities)
          .ThenInclude(join => join.Planet)
          .FirstOrDefault(planet => planet.PlanetId == PlanetId);
      if(thisPlanet.PlanetId == PlanetId)
      {
        _db.Entry(spaceship).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      else if(PlanetId != 0)
      {
        _db.PlanetSpaceships.Add(new PlanetSpaceship(){ PlanetId = PlanetId, SpaceshipId = spaceship.SpaceshipId});
      }
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
      // var thisPlanet = _db.Planets
      //     .Include(spaceship => spaceship.JoinEntities)
      //     .ThenInclude(join => join.Planet)
      //     .FirstOrDefault(planet => planet.PlanetId == PlanetId);
      // if(thisPlanet.PlanetId == PlanetId)
      // {

      //   _db.SaveChanges();
      //   return RedirectToAction("Index");
      // }

      //else 
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
        var joinEntry = _db.PlanetSpaceships.FirstOrDefault(entry => entry.PlanetSpaceshipId == joinId);
        _db.PlanetSpaceships.Remove(joinEntry);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
  }
}