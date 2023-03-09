using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTOs;

public class UsuarioDTO
{
    [Required] public int Id { get; set; }

    [Required] public string Nombre { get; set; }

    [Required] public string PrimerApellido { get; set; }

    [Required] public string SegundoApellido { get; set; }

    [Required] [EmailAddress] public string Correo { get; set; }

    [Required] public int TipodeUsuario { get; set; }
}