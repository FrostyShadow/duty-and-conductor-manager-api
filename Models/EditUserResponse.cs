using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class EditUserResponse : ResponseBase
{
    public EditUserResponse(bool isSuccess) : base(isSuccess) {}
    public EditUserResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage) {}
}