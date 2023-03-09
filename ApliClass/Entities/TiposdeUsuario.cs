using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class TiposdeUsuario
    {
        public TiposdeUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
