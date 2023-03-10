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
        public string Name { get; set; }
        public int TeacherId { get; set; }

        public virtual User Teacher { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
