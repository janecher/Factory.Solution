using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public  EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index(string searchEngineer)
    {
      if(!string.IsNullOrEmpty(searchEngineer))
      {
        var searchEngineers = _db.Engineers.Where(engineers => engineers.Name.Contains(searchEngineer) || engineers.LicinseName.Contains(searchEngineer)).ToList();                    
        return View(searchEngineers);
      }
      return View(_db.Engineers.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.MachineId = _db.Machines.ToList();
      ViewBag.LocationId = new SelectList(_db.Locations, "LocationId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer, int[] MachineId)
    {
      _db.Engineers.Add(engineer);
      if(MachineId.Length !=0)
      {
        foreach(int id in MachineId)
        {
          _db.EngineersMachines.Add(new EngineerMachine() { MachineId = id, EngineerId = engineer.EngineerId});
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult Details(int id)
    {
      var thisEngineer = _db.Engineers
        .Include(engineer => engineer.Incidents).ThenInclude(join => join.Incident)
        .Include(engineer => engineer.Machines).ThenInclude(join => join.Machine)
        .FirstOrDefault(engineers => engineers.EngineerId == id );

      return View(thisEngineer);
    }

    public ActionResult Edit(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id );
      ViewBag.MachineId = _db.Machines.ToList();
      ViewBag.LocationId = new SelectList(_db.Locations, "LocationId", "Name");
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer, int[] MachineId)
    {
      if(MachineId.Length !=0)
      {
        foreach(int id in MachineId)
        {
          _db.EngineersMachines.Add(new EngineerMachine() { MachineId = id, EngineerId = engineer.EngineerId});
        }
      }
      _db.Entry(engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteIncident(int engineerId, int incidentId)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == engineerId);
      var thisIncident = _db.Incidents.FirstOrDefault(incidents => incidents.IncidentId == incidentId);
      thisEngineer.Incidents.Remove(thisIncident);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddMachine(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id );
      ViewBag.MachineId = _db.Machines.ToList();
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult AddMachine(Engineer engineer, int[] MachineId)
    {
      if(MachineId.Length !=0)
      {
        foreach(int id in MachineId)
        {
          _db.EngineersMachines.Add(new EngineerMachine() { MachineId = id, EngineerId = engineer.EngineerId});
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    [HttpPost]
    public ActionResult DeleteMachine (int joinId)
    {
      var joinEntry = _db.EngineersMachines.FirstOrDefault(entry => entry.EngineerMachineId ==joinId);
      _db.EngineersMachines.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id );
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id );
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}