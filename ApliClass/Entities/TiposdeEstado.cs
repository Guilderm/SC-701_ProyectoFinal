using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class TiposdeEstado
    {
        public TiposdeEstado()
        {
            Asistencia = new HashSet<Asistencia>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Asistencia> Asistencia { get; set; }
    }
}
