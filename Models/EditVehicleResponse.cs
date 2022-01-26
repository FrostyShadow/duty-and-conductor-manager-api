using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class EditVehicleResponse : ResponseBase
{
    public EditVehicleResponse(bool isSuccess) : base(isSuccess)
    {}

    public EditVehicleResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
    {}
}