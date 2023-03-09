﻿using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class UsuariosListasdeEstudiante
    {
        public int UsuariosId { get; set; }
        public int ListasdeEstudiantesEstudiante { get; set; }

        public virtual Usuario Usuarios { get; set; } = null!;
    }
}
