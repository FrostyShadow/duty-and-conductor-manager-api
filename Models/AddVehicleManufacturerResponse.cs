using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class AddVehicleManufacturerResponse : ResponseBase
{
    public AddVehicleManufacturerResponse(bool isSuccess) : base(isSuccess)
    {

    }

    public AddVehicleManufacturerResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
    {
        
    }
}