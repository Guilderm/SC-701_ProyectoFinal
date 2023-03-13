namespace Entities;

public class Class
{
    public Class()
    {
        Assessments = new HashSet<Assessment>();
        Lessons = new HashSet<Lesson>();
        Students = new HashSet<Student>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int TeacherId { get; set; }

    public virtual User Teacher { get; set; }
    public virtual ICollection<Assessment> Assessments { get; set; }
    public virtual ICollection<Lesson> Lessons { get; set; }
    public virtual ICollection<Student> Students { get; set; }
}