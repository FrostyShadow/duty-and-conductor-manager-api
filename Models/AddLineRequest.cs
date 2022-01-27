namespace DutyAndConductorManager.Api.Models;

public class AddLineRequest
{
    public string Number {get;set;}
    public int LineTypeId {get;set;}
    public DateTime StartDateTime {get;set;}
    public DateTime EndDateTime {get;set;}
}