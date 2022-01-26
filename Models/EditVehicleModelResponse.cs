using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class EditVehicleModelResponse : ResponseBase
{
    public EditVehicleModelResponse(bool isSuccess) : base(isSuccess)
    {}

    public EditVehicleModelResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
    {}
}