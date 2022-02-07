namespace DutyAndConductorManager.Api.Models;

public class EditLineRequest
{
    public int Id {get;set;}
    public string Number {get;set;}
    public int LineTypeId {get;set;}
    public DateTime StartDateTime {get;set;}
    public DateTime EndDateTime {get;set;}
}