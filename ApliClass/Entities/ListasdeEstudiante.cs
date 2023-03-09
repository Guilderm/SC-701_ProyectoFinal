using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class ListasdeEstudiante
    {
        public int Id { get; set; }
        public int Estudiante { get; set; }
        public int Clase { get; set; }

        public virtual Clase ClaseNavigation { get; set; }
        public virtual Usuario EstudianteNavigation { get; set; }
    }
}
