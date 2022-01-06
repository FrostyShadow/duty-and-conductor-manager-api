namespace DutyAndConductorManager.Api.Entities;

public class SecurityTokenType
{
    public int Id {get;set;}
    public string Name {get;set;}

    public IList<SecurityToken> SecurityTokens {get;set;}
}