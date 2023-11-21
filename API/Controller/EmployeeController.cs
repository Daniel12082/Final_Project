using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using Application.Repository;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class EmployeeController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Employee>>> Get()
    {
        var entidades = await _unitOfWork.Employee.GetAllAsync();
        return _mapper.Map<List<Employee>>(entidades);
    }

    // [HttpGet("{id}")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // public async Task<ActionResult<EmployeeDto>> Get(int id)
    // {
    //     var entidad = await _unitOfWork.Employee.GetByIdAsync(id);
    //     if(entidad == null)
    //     {
    //         return NotFound();
    //     }
    //     return _mapper.Map<EmployeeDto>(entidad);
    // }
    [HttpGet("boss/{bossCode}")]
    public async Task<IActionResult> GetEmployeesByBossCode(int bossCode)
    {
        try
        {
            var employees = await EmployeeRepository.(IdBossFk);
            return Ok(employees);
        }
        catch (Exception ex)
        {
            // Manejar la excepción según tus necesidades
            return StatusCode(500, $"Error: {ex.Message}");
        }
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Employee>> Post(EmployeeDto EmployeeDto)
    {
        var entidad = _mapper.Map<Employee>(EmployeeDto);
        this._unitOfWork.Employee.Add(entidad);
        await _unitOfWork.SaveAsync();
        if (entidad == null)
        {
            return BadRequest();
        }
        EmployeeDto.Id = entidad.Id;
        return CreatedAtAction(nameof(Post), new { id = EmployeeDto.Id }, EmployeeDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmployeeDto>> Put(int id, [FromBody] EmployeeDto EmployeeDto)
    {
        if (EmployeeDto == null)
        {
            return NotFound();
        }
        var entidades = _mapper.Map<Employee>(EmployeeDto);
        _unitOfWork.Employee.Update(entidades);
        await _unitOfWork.SaveAsync();
        return EmployeeDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var entidad = await _unitOfWork.Employee.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        _unitOfWork.Employee.Delete(entidad);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}