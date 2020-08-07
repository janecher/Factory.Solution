using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public  MachinesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index(string searchMachine)
    {
      if(!string.IsNullOrEmpty(searchMachine))
      {
        var searchMachines = _db.Machines.Where(machines => machines.Name.Contains(searchMachine) || machines.Number.Contains(searchMachine)).ToList();                    
        return View(searchMachines);
      }
      return View(_db.Machines.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.LocationId = new SelectList(_db.Locations, "LocationId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult Details(int id)
    {
      var thisMachine = _db.Machines
        .Include(machine => machine.Incidents)
        .Include(machine => machine.Engineers).ThenInclude(join => join.Engineer)
        .FirstOrDefault(machines => machines.MachineId == id );

      return View(thisMachine);
    }

    public ActionResult Edit(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id );
      ViewBag.LocationId = new SelectList(_db.Locations, "LocationId", "Name");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine machine)
    {
      _db.Entry(machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteIncident(int machineId, int incidentId)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == machineId );
      var thisIncident = _db.Incidents.FirstOrDefault(incidents => incidents.IncidentId == incidentId);
      thisMachine.Incidents.Remove(thisIncident);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    [HttpPost]
    public ActionResult DeleteEngineer(int joinId)
    {
      var joinEntry = _db.EngineersMachines.FirstOrDefault(entry => entry.EngineerMachineId ==joinId);
      _db.EngineersMachines.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id );
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id );
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}