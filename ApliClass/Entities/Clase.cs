using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Clase
    {
        public Clase()
        {
            ClasesListasdeEstudiantes = new HashSet<ClasesListasdeEstudiante>();
            ClasesListasdeLecciones = new HashSet<ClasesListasdeLeccione>();
            ClasesNota = new HashSet<ClasesNota>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? Profesor { get; set; }

        public virtual ICollection<ClasesListasdeEstudiante> ClasesListasdeEstudiantes { get; set; }
        public virtual ICollection<ClasesListasdeLeccione> ClasesListasdeLecciones { get; set; }
        public virtual ICollection<ClasesNota> ClasesNota { get; set; }
    }
}
