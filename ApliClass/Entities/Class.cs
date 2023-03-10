namespace Entities;

public class Class
{
    public Class()
    {
        Grades = new HashSet<Grade>();
        Lessons = new HashSet<Lesson>();
        Students = new HashSet<Student>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Teacher { get; set; }

    public virtual User TeacherNavigation { get; set; }
    public virtual ICollection<Grade> Grades { get; set; }
    public virtual ICollection<Lesson> Lessons { get; set; }
    public virtual ICollection<Student> Students { get; set; }
}