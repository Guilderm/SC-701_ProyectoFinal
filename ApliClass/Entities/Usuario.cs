using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            UsuariosAsistencia = new HashSet<UsuariosAsistencia>();
            UsuariosListasdeEstudiantes = new HashSet<UsuariosListasdeEstudiante>();
            UsuariosNota = new HashSet<UsuariosNota>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? _1apellido { get; set; }
        public string? _2apellido { get; set; }
        public string? Coreo { get; set; }
        public int? TipodeUsuario { get; set; }

        public virtual ICollection<UsuariosAsistencia> UsuariosAsistencia { get; set; }
        public virtual ICollection<UsuariosListasdeEstudiante> UsuariosListasdeEstudiantes { get; set; }
        public virtual ICollection<UsuariosNota> UsuariosNota { get; set; }
    }
}
