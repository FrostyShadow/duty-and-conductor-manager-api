namespace DutyAndConductorManager.Api.Entities;

public class Line
{
    public int Id {get;set;}
    public string Number {get;set;}
    public int LineTypeId {get;set;}
    public DateTime StartDateTime {get;set;}
    public DateTime EndDateTime {get;set;}

    public LineType LineType {get;set;}    
}