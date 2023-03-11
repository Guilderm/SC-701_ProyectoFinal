using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTOs;

public class StudentDTO
{
    public int Id { get; set; }

    [Required] public int StudentId { get; set; }

    [Required] public int ClassId { get; set; }

    public ClassDTO Class { get; set; }
    public UserDTO Student { get; set; }
}