namespace Entities;

public class TypesOfState
{
    public TypesOfState()
    {
        Attendances = new HashSet<Attendance>();
    }

    public int Id { get; set; }
    public string Type { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; }
}