namespace DutyAndConductorManager.Api.Entities;

public class VehicleModel
{
    public int Id {get;set;}
    public string Name {get;set;}
    public int ManufacturerId {get;set;}
    public int VehicleTypeId {get;set;}
    public bool IsCoupleable {get;set;}

    public VehicleManufacturer Manufacturer {get;set;}
    public VehicleType VehicleType {get;set;}
    public IList<Vehicle> Vehicles {get;set;}
}