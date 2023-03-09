namespace BackEnd.DTOs;

public class UsuarioDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string PrimerApellido { get; set; }
    public string SegundoApellido { get; set; }
    public string Correo { get; set; }
    public int TipoDeUsuario { get; set; }
}