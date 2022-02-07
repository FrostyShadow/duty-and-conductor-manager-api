namespace DutyAndConductorManager.Api.Entities;

public class LineType
{
    public int Id {get;set;}
    public string Name {get;set;}

    public IList<Line> Lines {get;set;}
}