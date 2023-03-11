using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTOs;

public class TypesOfUserDTO
{
    public int Id { get; set; }

    [StringLength(50)]
    [Required(ErrorMessage = "The Type field is required.")]

    public string Type { get; set; }
}