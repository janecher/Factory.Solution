using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      this.Incidents = new HashSet<Incident>();
      this.Machines = new HashSet<EngineerMachine>();
    }
    public int EngineerId {get; set;}
    public string Name {get; set;}
    public string LicenseName {get; set;}
    public bool IsActive {get; set;}
    public virtual ICollection<Incident> Incidents {get; set;}
    public virtual ICollection<EngineerMachine> Machines {get; set;}
    public int LocationId {get; set;}
    public virtual Location Location {get; set;}
  }
}