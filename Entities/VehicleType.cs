namespace DutyAndConductorManager.Api.Entities;

public class VehicleType
{
    public int Id {get;set;}
    public string Name {get;set;}
    public bool IsCoupleable {get;set;}

    public IList<VehicleModel> Models {get;set;}
}