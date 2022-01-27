namespace DutyAndConductorManager.Api.Models;

public class AddVehicleModelRequest
{
    public string Name {get;set;}
    public int ManufacturerId {get;set;}
    public int VehicleTypeId {get;set;}
    public bool IsCoupleable {get;set;}
}