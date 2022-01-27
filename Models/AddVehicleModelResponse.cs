using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class AddVehicleModelResponse : ResponseBase
{
    public AddVehicleModelResponse(bool isSuccess) : base(isSuccess)
    {

    }

    public AddVehicleModelResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
    {
        
    }
}