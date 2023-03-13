using AutoMapper;
using BackEnd.DTOs;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

public class StudentController : GenericControllers<Student, StudentDTO>
{
    private readonly ILogger<StudentController> _logger;

    public StudentController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<StudentController> logger) : base(
        unitOfWork, mapper)
    {
        _logger = logger;
    }

    #region POST|Create - Used to create a new resource.

    [HttpPost]
    public override IActionResult Post([FromBody] StudentDTO requestDto)
    {
        _logger.LogInformation($"will look for Entity with of name {nameof(requestDto)} and see if we get it.");

        if (!ModelState.IsValid)
        {
            _logger.LogError($"Invalid POST attempt in {nameof(requestDto)}");
            return BadRequest(ModelState);
        }

        Student mappedResult = Mapper.Map<Student>(requestDto);

        Repository.Insert(mappedResult);
        UnitOfWork.SaveChanges();

        _logger.LogCritical($"The ID of Entity with of name {nameof(requestDto)} is {mappedResult.StudentId} .");

        return CreatedAtAction(nameof(Get), new { id = mappedResult.StudentId }, mappedResult);
    }

    #endregion
}