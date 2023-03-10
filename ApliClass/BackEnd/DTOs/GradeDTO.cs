using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTOs;

public class GradeDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "StudentId is required.")]
    public int StudentId { get; set; }

    [Required(ErrorMessage = "ClassId is required.")]
    public int ClassId { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(50)]
    public string Name { get; set; }

    [Required(ErrorMessage = "Grade is required.")]
    [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100.")]
    public double Grade { get; set; }

    [Required(ErrorMessage = "Percentage is required.")]
    [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100.")]
    public double Percentage { get; set; }
}