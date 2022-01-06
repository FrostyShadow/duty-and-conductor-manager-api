namespace DutyAndConductorManager.Api.Models;

public class PasswordResetRequest
{
    public int Id {get;set;}
    public Guid Token {get;set;}
}