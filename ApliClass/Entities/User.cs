namespace Entities;

public class User
{
    public User()
    {
        Attendances = new HashSet<Attendance>();
        Classes = new HashSet<Class>();
        Grades = new HashSet<Grade>();
        Students = new HashSet<Student>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string PrimerApellido { get; set; }
    public string SegundoApellido { get; set; }
    public string Email { get; set; }
    public int UserType { get; set; }

    public virtual TypesOfUser UserTypeNavigation { get; set; }
    public virtual ICollection<Attendance> Attendances { get; set; }
    public virtual ICollection<Class> Classes { get; set; }
    public virtual ICollection<Grade> Grades { get; set; }
    public virtual ICollection<Student> Students { get; set; }
}