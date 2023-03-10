using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTOs;

public class AttendanceDTO
{
    [Required(ErrorMessage = "Attendance date is required.")]
    public DateTime AttendanceDate { get; set; }

    [Required(ErrorMessage = "Student ID is required.")]
    public int StudentId { get; set; }

    [Required(ErrorMessage = "Class ID is required.")]
    public int ClassId { get; set; }

    [Required(ErrorMessage = "Attendance state is required.")]
    public int AttendanceStateId { get; set; }
}