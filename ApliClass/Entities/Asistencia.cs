using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Asistencia
    {
        public int Id { get; set; }
        public int Leccion { get; set; }
        public int Estudiante { get; set; }
        public int Estado { get; set; }

        public virtual TiposdeEstado EstadoNavigation { get; set; }
        public virtual Usuario EstudianteNavigation { get; set; }
        public virtual ListasdeLeccione LeccionNavigation { get; set; }
    }
}
