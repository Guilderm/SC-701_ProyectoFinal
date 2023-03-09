using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class UsuariosNota
    {
        public int UsuariosId { get; set; }
        public int NotasEstudiante { get; set; }

        public virtual Usuario Usuarios { get; set; } = null!;
    }
}
