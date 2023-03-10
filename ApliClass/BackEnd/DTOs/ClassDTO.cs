using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTOs;

public class ClassDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Name field is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The Teacher field is required")]
    public int Teacher { get; set; }

    public UserDTO TeacherNavigation { get; set; }

    public ICollection<GradeDTO> Grades { get; set; }

    public ICollection<LessonDTO> Lessons { get; set; }

    public ICollection<StudentDTO> Students { get; set; }
}