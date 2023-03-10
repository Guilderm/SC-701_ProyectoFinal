using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTOs;

public class AttendanceDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Lessons field is required.")]
    public int Lessons { get; set; }

    [Required(ErrorMessage = "The Student field is required.")]
    public int Student { get; set; }

    [Required(ErrorMessage = "The State field is required.")]
    public int State { get; set; }

    public virtual LessonDTO LessonsNavigation { get; set; }
    public virtual TypesOfStateDTO StateNavigation { get; set; }
    public virtual UserDTO StudentNavigation { get; set; }
}