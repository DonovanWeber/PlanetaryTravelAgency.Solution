using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PlanetaryTravelAgency.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlanetaryTravelAgency.Controllers
{
  public class PlanetsController : Controller
  {
    private readonly PlanetaryTravelAgencyContext _db;
    
    public PlanetsController(PlanetaryTravelAgencyContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Planet> model = _db.Planets.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.PlanetId = new SelectList(_db.Planets, "PlanetId","Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Planet planet)
    {
      _db.Planets.Add(planet);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisPlanet = _db.Planets
          .Include(planet => planet.JoinEntities)
          .ThenInclude(join => join.Spaceship)
          .FirstOrDefault(planet => planet.PlanetId == id);
      return View(thisPlanet);
    }

    public ActionResult Edit(int id)
    {
      Planet thisPlanet = _db.Planets.FirstOrDefault(planet => planet.PlanetId == id);
      ViewBag.SpaceshipId = new SelectList(_db.Spaceships, "SpaceshipId", "Name");
      return View(thisPlanet);
    }

    [HttpPost]
    public ActionResult Edit(Planet planet)
    {
      _db.Entry(planet).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisPlanet = _db.Planets.FirstOrDefault(planet => planet.PlanetId == id);
      return View(thisPlanet);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisPlanet = _db.Planets.FirstOrDefault(planet => planet.PlanetId == id);
      _db.Planets.Remove(thisPlanet);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}