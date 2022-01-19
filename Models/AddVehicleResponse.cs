using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class AddVehicleResponse : ResponseBase
{
    public AddVehicleResponse(bool isSuccess) : base(isSuccess)
    {

    }

    public AddVehicleResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
    {
        
    }
}