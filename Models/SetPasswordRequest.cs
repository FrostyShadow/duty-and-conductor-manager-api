namespace DutyAndConductorManager.Api.Models;

public class SetPasswordRequest
{
    public int Id {get;set;}
    public Guid Token {get;set;}
    public string Password {get;set;}
}