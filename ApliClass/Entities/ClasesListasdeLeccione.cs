using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class ClasesListasdeLeccione
    {
        public int ClasesId { get; set; }
        public int ListasdeLeccionesClase { get; set; }

        public virtual Clase Clases { get; set; } = null!;
    }
}
