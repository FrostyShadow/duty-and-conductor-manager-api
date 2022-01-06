using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class DeleteUserResponse : ResponseBase
{
    public DeleteUserResponse(bool isSuccess) : base(isSuccess) {}
    public DeleteUserResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage) {}
}