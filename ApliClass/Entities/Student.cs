using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Student
    {
        public int Id { get; set; }
        public int Estudiante { get; set; }
        public int Clase { get; set; }

        public virtual Class ClaseNavigation { get; set; }
        public virtual User EstudianteNavigation { get; set; }
    }
}
