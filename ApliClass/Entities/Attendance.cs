namespace Entities;

public class Attendance
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public int StudentId { get; set; }
    public int StateId { get; set; }

    public virtual Lesson Lesson { get; set; }
    public virtual AttendanceState State { get; set; }
    public virtual User Student { get; set; }
}