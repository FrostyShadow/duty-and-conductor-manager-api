using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class DeleteLineResponse : ResponseBase
{
    public DeleteLineResponse(bool isSuccess) : base(isSuccess) {}
    public DeleteLineResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage) {}
}