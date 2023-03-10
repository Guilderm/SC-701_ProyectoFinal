using AutoMapper;
using BackEnd.DTOs;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

public class AttendanceController : GenericControllers<Attendance, AttendanceDTO>
{
    private readonly ILogger<AttendanceController> _logger;

    public AttendanceController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AttendanceController> logger) : base(
        unitOfWork, mapper)
    {
        _logger = logger;
    }

    #region POST|Create - Used to create a new resource.

    [HttpPost]
    public override IActionResult Post([FromBody] AttendanceDTO requestDto)
    {
        _logger.LogInformation($"will look for Entity with of name {nameof(requestDto)} and see if we get it.");

        if (!ModelState.IsValid)
        {
            _logger.LogError($"Invalid POST attempt in {nameof(requestDto)}");
            return BadRequest(ModelState);
        }

        Attendance mappedResult = Mapper.Map<Attendance>(requestDto);

        Repository.Insert(mappedResult);
        UnitOfWork.SaveChanges();

        _logger.LogCritical($"The ID of Entity with of name {nameof(requestDto)} is {mappedResult.Id} .");

        return CreatedAtAction(nameof(Get), new { id = mappedResult.Id }, mappedResult);
    }

    #endregion
}