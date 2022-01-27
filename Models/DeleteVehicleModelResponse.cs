using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class DeleteVehicleModelResponse : ResponseBase
{
    public DeleteVehicleModelResponse(bool isSuccess) : base(isSuccess) {}
    public DeleteVehicleModelResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage) {}
}