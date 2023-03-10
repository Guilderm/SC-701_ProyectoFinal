using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Class
    {
        public Class()
        {
            Grades = new HashSet<Grade>();
            Lessons = new HashSet<Lesson>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Profesor { get; set; }

        public virtual User ProfesorNavigation { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
