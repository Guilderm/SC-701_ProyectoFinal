namespace Entities;

public class Student
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int ClassId { get; set; }

    public virtual Class Class { get; set; }
    public virtual User StudentNavigation { get; set; }
}