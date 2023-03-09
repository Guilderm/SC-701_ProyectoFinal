namespace Entities;

public class Nota
{
    public int Id { get; set; }
    public int? Estudiante { get; set; }
    public int? Clase { get; set; }
    public string Nombre { get; set; }
    public double? Nota1 { get; set; }
    public double? Porcentaje { get; set; }
}