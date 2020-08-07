using System.Collections.Generic;

namespace Factory.Models
{
  public class Incident
  {
    public Incident()
    {
      this.Machines = new HashSet<Machine>();
      this.Engineers = new HashSet<Engineer>();
    }
    public int IncidentId {get; set;}
    public string Type {get; set;}
    public bool Status {get; set;}
    public virtual ICollection<Machine> Machines {get; set;}
    public virtual ICollection<Engineer> Engineers {get; set;}
  }
}