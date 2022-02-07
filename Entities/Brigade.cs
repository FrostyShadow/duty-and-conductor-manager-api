namespace DutyAndConductorManager.Api.Entities;

public class Brigade
{
    public int Id {get;set;}
    public string Name {get;set;}
    public DateTime DateTimeFrom {get;set;}
    public DateTime DateTimeTo {get;set;}
    public int ConductorLimit {get;set;}
    public int SetId {get;set;}
    public int LineId {get;set;}
    public bool IsActive {get;set;}
    
    public Set Set {get;set;}
    public Line Line {get;set;}
    public IList<BrigadeUser> BrigadeUsers {get;set;}
}