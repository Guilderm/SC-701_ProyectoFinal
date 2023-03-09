using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class ListasdeLeccionesAsistencia
    {
        public int ListasdeLeccionesId { get; set; }
        public int AsistenciasLeccion { get; set; }

        public virtual ListasdeLeccione ListasdeLecciones { get; set; } = null!;
    }
}
