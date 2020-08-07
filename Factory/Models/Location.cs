using System.Collections.Generic;

namespace Factory.Models
{
  public class Location
  {
    public Location()
    {
      this.Machines = new HashSet<Machine>();
      this.Engineers = new HashSet<Engineer>();
    }
    public int LocationId {get; set;}
    public string Address {get; set;}
    public virtual ICollection<Machine> Machines {get; set;}
    public virtual ICollection<Engineer> Engineers {get; set;}
  }
}