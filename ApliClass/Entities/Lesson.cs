namespace Entities;

public class Lesson
{
    public Lesson()
    {
        Attendances = new HashSet<Attendance>();
    }

    public int Id { get; set; }
    public int Class { get; set; }
    public string Number { get; set; }
    public byte[] Date { get; set; }

    public virtual Class ClassNavigation { get; set; }
    public virtual ICollection<Attendance> Attendances { get; set; }
}