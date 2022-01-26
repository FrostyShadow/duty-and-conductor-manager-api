using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class EditVehicleManufacturerResponse : ResponseBase
{
    public EditVehicleManufacturerResponse(bool isSuccess) : base(isSuccess)
    {}

    public EditVehicleManufacturerResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
    {}
}