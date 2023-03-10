using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTOs;

public class TypesOfStateDTO
{
    public int Id { get; set; }

    [Required] public string Type { get; set; }
}