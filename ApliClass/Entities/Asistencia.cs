using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Asistencia
    {
        public int Id { get; set; }
        public int? Leccion { get; set; }
        public int? Estudiante { get; set; }
        public string? Estado { get; set; }
    }
}
