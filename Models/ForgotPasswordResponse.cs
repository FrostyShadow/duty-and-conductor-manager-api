using DutyAndConductorManager.Api.Helpers;

namespace DutyAndConductorManager.Api.Models;

public class ForgotPasswordResponse : ResponseBase
{
    public ForgotPasswordResponse(bool isSuccess) : base(isSuccess) {}
    public ForgotPasswordResponse(bool isSuccess, string errorMessage) : base(isSuccess, errorMessage) {}
}