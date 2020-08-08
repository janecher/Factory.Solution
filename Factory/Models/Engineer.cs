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
    public string License {get; set;}
    public string Active 
    { get
      {
        if(Incidents.Count != 0)
        {
          return "Active";
        }
        else
        {
          return "";
        }
      }
    }
    public virtual ICollection<Incident> Incidents {get; set;}
    public virtual ICollection<EngineerMachine> Machines {get; set;}
    public int LocationId {get; set;}
    public virtual Location Location {get; set;}
  }
}