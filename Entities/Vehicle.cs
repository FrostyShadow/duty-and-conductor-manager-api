namespace DutyAndConductorManager.Api.Entities;

public class Vehicle
{
    public int Id {get;set;}
    public int ModelId {get;set;}
    public string SideNumber {get;set;}

    public VehicleModel Model {get;set;}
    public IList<VehicleSet> VehicleSets {get;set;}
}