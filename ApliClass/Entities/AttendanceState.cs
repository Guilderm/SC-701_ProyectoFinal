using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class AttendanceState
    {
        public AttendanceState()
        {
            Attendances = new HashSet<Attendance>();
        }

        public int Id { get; set; }
        public string State { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
