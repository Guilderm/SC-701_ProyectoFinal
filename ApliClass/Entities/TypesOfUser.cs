namespace Entities;

public class TypesOfUser
{
    public TypesOfUser()
    {
        Users = new HashSet<User>();
    }

    public int Id { get; set; }
    public string Type { get; set; }

    public virtual ICollection<User> Users { get; set; }
}