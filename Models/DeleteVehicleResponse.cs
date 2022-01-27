using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class DeleteVehicleResponse : ResponseBase
{
    public DeleteVehicleResponse(bool isSuccess) : base(isSuccess) {}
    public DeleteVehicleResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage) {}
}