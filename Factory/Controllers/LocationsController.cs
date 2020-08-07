using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class LocationsController : Controller
  {
    private readonly FactoryContext _db;

    public  LocationsController(FactoryContext db)
    {
      _db = db;
    } 

    public ActionResult Index(string searchLocation)
    {
      if(!string.IsNullOrEmpty(searchLocation))
      {
        var searchLocations = _db.Locations.Where(locations => locations.Name.Contains(searchLocation) || courses.Address.Contains(searchLocation)).ToList();                    
        return View(searchLocations);
      }
      return View(_db.Locations.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Location location)
    {
      _db.Locations.Add(location);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisLocation  = _db.Locations
        .Include(location => location.Machines)
        .Include(location => location.Engineers)
        .FirstOrDefault(locations => locations.LocationId == id);
      return View(thisLocation);
    }

    public ActionResult Edit(int id)
    {
      var thisLocation = _db.Locations.FirstOrDefault(locations => locations.LocationId == id);
      return View(thisLocation);
    }

    [HttpPost]
    public ActionResult Edit(Location location)
    {
      _db.Entry(location).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisLocation = _db.Locations.FirstOrDefault(locations => locations.LocationId == id);
      return View(thisLocation);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisLocation = _db.Locations.FirstOrDefault(locations => locations.LocationId == id);
      _db.Locations.Remove(thisLocation);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteMachine(int locationId, int machineId)
    {
      var thisLocation = _db.Locations.FirstOrDefault(locations => locations.LocationId == locationId);
      var thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == machineId);
      thisLocation.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteEngineer(int locationId, int engineerId)
    {
      var thisLocation = _db.Locations.FirstOrDefault(locations => locations.LocationId == locationId);
      var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == engineerId);
      thisLocation.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}