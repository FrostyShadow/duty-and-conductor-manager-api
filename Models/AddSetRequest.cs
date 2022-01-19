using DutyAndConductorManager.Api.Entities;

namespace DutyAndConductorManager.Api.Models;

public class AddSetRequest
{
    public string Name {get;set;}
    public IList<VehicleSet> Vehicles {get;set;}
}