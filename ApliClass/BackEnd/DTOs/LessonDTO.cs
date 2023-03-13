using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTOs;

public class LessonDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The ClassId field is required.")]
    public int ClassId { get; set; }

    [Required(ErrorMessage = "The Name field is required.")]
    [StringLength(50, ErrorMessage = "The Name field must be at most {1} characters long.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The Date field is required.")]
    public DateTime Date { get; set; }

    public ClassDTO Class { get; set; }
    public ICollection<AttendanceDTO> Attendances { get; set; }
}