using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class DeleteSetResponse : ResponseBase
{
    public DeleteSetResponse(bool isSuccess) : base(isSuccess) {}
    public DeleteSetResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage) {}
}