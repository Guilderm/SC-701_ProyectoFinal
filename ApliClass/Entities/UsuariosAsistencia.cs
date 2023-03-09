using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class UsuariosAsistencia
    {
        public int UsuariosId { get; set; }
        public int AsistenciasEstudiante { get; set; }

        public virtual Usuario Usuarios { get; set; } = null!;
    }
}
