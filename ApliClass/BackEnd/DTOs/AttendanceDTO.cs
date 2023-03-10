using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTOs;

public class AttendanceDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Lesson Id is required")]
    public int LessonId { get; set; }

    [Required(ErrorMessage = "Student Id is required")]
    public int StudentId { get; set; }

    [Required(ErrorMessage = "State Id is required")]
    public int StateId { get; set; }

    public LessonDTO Lesson { get; set; }

    public AttendanceStateDTO State { get; set; }

    public UserDTO Student { get; set; }
}