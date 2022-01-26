using DutyAndConductorManager.Api.Entities;

namespace DutyAndConductorManager.Api.Models;

public class EditSetRequest
{
    public int Id {get;set;}
    public string Name {get;set;}
    
    public IList<VehicleSet> VehicleSets {get;set;}
}