using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Lesson
    {
        public Lesson()
        {
            Attendances = new HashSet<Attendance>();
        }

        public int Id { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public byte[] Date { get; set; }

        public virtual Class Class { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
