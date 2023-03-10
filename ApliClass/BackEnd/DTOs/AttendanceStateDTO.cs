using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTOs;

public class AttendanceStateDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Attendance state name is required.")]
    [StringLength(50, ErrorMessage = "The State name field cannot exceed 50 characters")]
    public string AttendanceStateName { get; set; }
}