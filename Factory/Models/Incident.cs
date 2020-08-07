using System.Collections.Generic;

namespace Factory.Models
{
  public class Incident
  {
    public Incident()
    {
      Status = true;
    }
    public int IncidentId {get; set;}
    public string Type {get; set;}
    public bool Status {get; set;}

    public string StatusInfo 
    { get 
      { 
        if(Status) 
        {
          return "Active";
        }
        else
        {
          return "Closed";
        }
      }
    }
    public int EngineerId {get; set;}
    public int MachineId{ get; set;}
    public virtual Machine Machines {get; set;}
    public virtual Engineer Engineers {get; set;}
  }
}