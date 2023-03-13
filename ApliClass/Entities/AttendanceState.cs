namespace Entities;

public class AttendanceState
{
    public AttendanceState()
    {
        Attendances = new HashSet<Attendance>();
    }

    public int Id { get; set; }
    public string State { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; }
}