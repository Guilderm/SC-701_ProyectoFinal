using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Attendance
    {
        public int Id { get; set; }
        public int Lessons { get; set; }
        public int Estudiante { get; set; }
        public int Estado { get; set; }

        public virtual TiposdeEstado EstadoNavigation { get; set; }
        public virtual User EstudianteNavigation { get; set; }
        public virtual Lesson LessonsNavigation { get; set; }
    }
}
