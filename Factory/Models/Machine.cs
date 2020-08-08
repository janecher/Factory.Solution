using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      this.Incidents = new HashSet<Incident>();
      this.Engineers = new HashSet<EngineerMachine>();
    }
    public int MachineId {get; set;}
    public string Name {get; set;}
    public string Status 
    { get
      {
        if(Incidents.Count != 0)
        {
          return "Malfunctioning";
        }
        else
        {
          return "Operational";
        }
      }
    }
    public virtual ICollection<Incident> Incidents {get; set;}
    public virtual ICollection<EngineerMachine> Engineers {get; set;}
    public int LocationId {get; set;}
    public virtual Location Location {get; set;}
  }
}