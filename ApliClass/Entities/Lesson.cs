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
        public int Clase { get; set; }
        public string Numero { get; set; }
        public byte[] Fecha { get; set; }

        public virtual Class ClaseNavigation { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
