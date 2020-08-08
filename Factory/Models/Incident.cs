using System.Collections.Generic;

namespace Factory.Models
{
  public class Incident
  {
    public int IncidentId {get; set;}
    public string Description {get; set;}
    public int EngineerId {get; set;}
    public int MachineId{ get; set;}
    public virtual Machine Machine {get; set;}
    public virtual Engineer Engineer {get; set;}
  }
}