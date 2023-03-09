using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Asistencia = new HashSet<Asistencia>();
            Clases = new HashSet<Clase>();
            ListasdeEstudiantes = new HashSet<ListasdeEstudiante>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public int TipodeUsuario { get; set; }

        public virtual TiposdeUsuario TipodeUsuarioNavigation { get; set; }
        public virtual ICollection<Asistencia> Asistencia { get; set; }
        public virtual ICollection<Clase> Clases { get; set; }
        public virtual ICollection<ListasdeEstudiante> ListasdeEstudiantes { get; set; }
    }
}
