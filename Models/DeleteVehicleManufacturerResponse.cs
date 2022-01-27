using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class DeleteVehicleManufacturerResponse : ResponseBase
{
    public DeleteVehicleManufacturerResponse(bool isSuccess) : base(isSuccess) {}
    public DeleteVehicleManufacturerResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage) {}
}