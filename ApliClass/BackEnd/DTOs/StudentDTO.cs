using System.ComponentModel.DataAnnotations;
using Entities;

namespace BackEnd.DTOs;

public class StudentDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Student ID is required.")]
    public int StudentId { get; set; }

    [Required(ErrorMessage = "Class ID is required.")]
    public int ClassId { get; set; }

    public virtual Class Class { get; set; }

    public virtual User StudentNavigation { get; set; }
}