using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class DeleteBrigadeResponse : ResponseBase
{
    public DeleteBrigadeResponse(bool isSuccess) : base(isSuccess) {}
    public DeleteBrigadeResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage) {}
}