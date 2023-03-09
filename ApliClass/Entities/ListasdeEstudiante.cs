using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class ListasdeEstudiante
    {
        public int Id { get; set; }
        public int? Estudiante { get; set; }
        public int? Clase { get; set; }
    }
}
