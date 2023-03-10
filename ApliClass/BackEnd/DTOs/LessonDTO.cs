using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTOs;

public class LessonDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Class field is required.")]
    public int Class { get; set; }

    [Required(ErrorMessage = "The Number field is required.")]
    [StringLength(10, ErrorMessage = "The Number field must be at most {1} characters long.")]
    public string Number { get; set; }

    [Required(ErrorMessage = "The Date field is required.")]
    public byte[] Date { get; set; }
}