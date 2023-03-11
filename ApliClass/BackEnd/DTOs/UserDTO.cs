using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTOs;

public class UserDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "First last name is required")]
    public string PrimerApellido { get; set; }

    public string SegundoApellido { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "User type is required")]
    public int UserType { get; set; }
}