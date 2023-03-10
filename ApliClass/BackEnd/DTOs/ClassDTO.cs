using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTOs;

public class ClassDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The Teacher ID is required")]
    public int TeacherId { get; set; }

    public UserDTO TeacherNavigation { get; set; }

    public ICollection<AssessmentDTO> Grades { get; set; }

    public ICollection<LessonDTO> Lessons { get; set; }

    public ICollection<StudentDTO> Students { get; set; }
}