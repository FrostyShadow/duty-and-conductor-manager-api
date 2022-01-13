namespace DutyAndConductorManager.Api.Entities;

public class VehicleManufacturer
{
    public int Id {get;set;}
    public string Name {get;set;}

    public IList<VehicleModel> Models {get;set;}
}