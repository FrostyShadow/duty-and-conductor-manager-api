namespace DutyAndConductorManager.Api.Models;

public class EditBrigadeRequest
{
    public int Id {get;set;}
    public string Name {get;set;}
    public DateTime DateTimeFrom {get;set;}
    public DateTime DateTimeTo {get;set;}
    public int ConductorLimit {get;set;}
    public int SetId {get;set;}
    public int LineId {get;set;}
    public bool IsActive {get;set;}
}