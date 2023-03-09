using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class ListasdeLeccione
    {
        public ListasdeLeccione()
        {
            Asistencia = new HashSet<Asistencia>();
        }

        public int Id { get; set; }
        public int Clase { get; set; }
        public string Numero { get; set; }
        public byte[] Fecha { get; set; }

        public virtual Clase ClaseNavigation { get; set; }
        public virtual ICollection<Asistencia> Asistencia { get; set; }
    }
}
