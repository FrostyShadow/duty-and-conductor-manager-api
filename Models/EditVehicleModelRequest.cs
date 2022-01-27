namespace DutyAndConductorManager.Api.Models;

public class EditVehicleModelRequest
{
    public int Id {get;set;}
    public string Name {get;set;}
    public int ManufacturerId {get;set;}
    public int VehicleTypeId {get;set;}
    public bool IsCoupleable {get;set;}
}