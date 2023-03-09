using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class ClasesListasdeEstudiante
    {
        public int ClasesId { get; set; }
        public int ListasdeEstudiantesClase { get; set; }

        public virtual Clase Clases { get; set; } = null!;
    }
}
