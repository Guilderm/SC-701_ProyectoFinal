using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Clase
    {
        public Clase()
        {
            ListasdeEstudiantes = new HashSet<ListasdeEstudiante>();
            ListasdeLecciones = new HashSet<ListasdeLeccione>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Profesor { get; set; }

        public virtual Usuario ProfesorNavigation { get; set; }
        public virtual ICollection<ListasdeEstudiante> ListasdeEstudiantes { get; set; }
        public virtual ICollection<ListasdeLeccione> ListasdeLecciones { get; set; }
    }
}
