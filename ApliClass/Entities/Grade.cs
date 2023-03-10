namespace Entities;

public class Grade
{
    public int Id { get; set; }
    public int Students { get; set; }
    public int Classes { get; set; }
    public string Name { get; set; }
    public double Grade1 { get; set; }
    public double Percentage { get; set; }

    public virtual Class ClassesNavigation { get; set; }
    public virtual User StudentsNavigation { get; set; }
}