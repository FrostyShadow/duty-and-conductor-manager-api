namespace DutyAndConductorManager.Api.Entities;

public class VehicleSet
{
    public int SetId {get;set;}
    public int VehicleId {get;set;}
    public int Index {get;set;}

    public Vehicle? Vehicle {get;set;}
    public Set? Set {get;set;}
}