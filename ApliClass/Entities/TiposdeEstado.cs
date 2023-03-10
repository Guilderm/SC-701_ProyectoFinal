using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class TiposdeEstado
    {
        public TiposdeEstado()
        {
            Attendances = new HashSet<Attendance>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
