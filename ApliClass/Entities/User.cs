using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class User
    {
        public User()
        {
            Attendances = new HashSet<Attendance>();
            Classes = new HashSet<Class>();
            Grades = new HashSet<Grade>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public int TipodeUsuario { get; set; }

        public virtual UserType TipodeUsuarioNavigation { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
