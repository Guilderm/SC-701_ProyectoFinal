using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTOs;

public class GradeDTO
{
    public int Id { get; set; }

    [Required] public int StudentId { get; set; }

    [Required] public int ClassId { get; set; }

    [Required] [StringLength(50)] public string Name { get; set; }

    [Required] [Range(0, 100)] public double Grade { get; set; }

    [Required] [Range(0, 100)] public double Percentage { get; set; }
}