using AutoMapper;
using BackEnd.DTOs;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

public class ClassController : GenericControllers<Class, ClassDTO>
{
    private readonly ILogger<ClassController> _logger;

    public ClassController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ClassController> logger) : base(
        unitOfWork, mapper)
    {
        _logger = logger;
    }

    #region POST|Create - Used to create a new resource.

    [HttpPost]
    public override IActionResult Post([FromBody] ClassDTO requestDto)
    {
        _logger.LogInformation($"will look for Entity with of name {nameof(requestDto)} and see if we get it.");

        if (!ModelState.IsValid)
        {
            _logger.LogError($"Invalid POST attempt in {nameof(requestDto)}");
            return BadRequest(ModelState);
        }

        Class mappedResult = Mapper.Map<Class>(requestDto);

        Repository.Insert(mappedResult);
        UnitOfWork.SaveChanges();

        _logger.LogCritical($"The ID of Entity with of name {nameof(requestDto)} is {mappedResult.Id} .");

        return CreatedAtAction(nameof(Get), new { id = mappedResult.Id }, mappedResult);
    }

    #endregion
}