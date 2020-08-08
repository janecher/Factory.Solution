using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class IncidentsController : Controller
  {
    private readonly FactoryContext _db;

    public  IncidentsController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Incidents.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.MachinesNumber = _db.Machines.ToList().Count;
      ViewBag.EngineersNumber = _db.Engineers.ToList().Count;
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Incident incident)
    {
      _db.Incidents.Add(incident);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult Details(int id)
    {
      var thisIncident = _db.Incidents
        .Include(incident => incident.Machine)
        .Include(incident => incident.Engineer)        
        .FirstOrDefault(incidents => incidents.IncidentId == id);

      return View(thisIncident);
    }

    public ActionResult Edit(int id)
    {
      var thisIncident = _db.Incidents.FirstOrDefault(incidents => incidents.IncidentId ==id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(thisIncident);
    }

    [HttpPost]
    public ActionResult Edit(Incident incident)
    {
      _db.Entry(incident).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
 
    public ActionResult Delete(int id)
    {
      var thisIncident = _db.Incidents.FirstOrDefault(incidents => incidents.IncidentId ==id);
      return View(thisIncident);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisIncident = _db.Incidents.FirstOrDefault(incidents => incidents.IncidentId ==id);
      _db.Incidents.Remove(thisIncident);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}