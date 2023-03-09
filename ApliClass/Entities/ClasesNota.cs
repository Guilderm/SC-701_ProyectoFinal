using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class ClasesNota
    {
        public int ClasesId { get; set; }
        public int NotasClase { get; set; }

        public virtual Clase Clases { get; set; } = null!;
    }
}
