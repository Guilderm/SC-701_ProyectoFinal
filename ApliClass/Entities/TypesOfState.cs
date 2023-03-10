using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class TypesOfState
    {
        public TypesOfState()
        {
            Attendances = new HashSet<Attendance>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
