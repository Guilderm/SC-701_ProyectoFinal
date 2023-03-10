using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTOs;

public class AttendanceDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Class ID is required.")]
    public int LessonId { get; set; }

    [Required(ErrorMessage = "Student ID is required.")]
    public int StudentId { get; set; }

    [Required(ErrorMessage = "Attendance state is required.")]
    public int StateId { get; set; }
}