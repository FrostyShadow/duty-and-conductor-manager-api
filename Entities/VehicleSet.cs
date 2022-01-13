namespace DutyAndConductorManager.Api.Entities;

public class VehicleSet
{
    public int Id {get;set;}
    public int VehicleId {get;set;}
    public int? ParentId {get;set;}

    public VehicleModel Vehicle {get;set;}
    public VehicleSet Parent {get;set;}
}