namespace Entities;

public class ListasdeLeccione
{
    public ListasdeLeccione()
    {
        ListasdeLeccionesAsistencia = new HashSet<ListasdeLeccionesAsistencia>();
    }

    public int Id { get; set; }
    public int? Clase { get; set; }
    public string Numero { get; set; }
    public byte[] Fecha { get; set; } = null!;

    public virtual ICollection<ListasdeLeccionesAsistencia> ListasdeLeccionesAsistencia { get; set; }
}