namespace DutyAndConductorManager.Api.Models;

public class AddBrigadeRequest
{
    public string Name {get;set;}
    public DateTime DateTimeFrom {get;set;}
    public DateTime DateTimeTo {get;set;}
    public int ConductorLimit {get;set;}
    public int SetId {get;set;}
    public int LineId {get;set;}
    public bool IsActive {get;set;}
}