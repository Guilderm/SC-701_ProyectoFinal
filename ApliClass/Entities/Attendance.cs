namespace Entities;

public class Attendance
{
    public int Id { get; set; }
    public int Lessons { get; set; }
    public int Student { get; set; }
    public int State { get; set; }

    public virtual Lesson LessonsNavigation { get; set; }
    public virtual TypesOfState StateNavigation { get; set; }
    public virtual User StudentNavigation { get; set; }
}