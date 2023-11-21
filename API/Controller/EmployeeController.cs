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
    public async Task<ActionResult<OfficeDto>> Get(int consulting)
    {
        switch (consulting)
        {
            case 1:
                var office = await _unitOfWork.Employee.GetEmployeesWithBossCode7();
                return Ok(office);
            case 2:
                var office2 = await _unitOfWork.Employee.GetBossInformation();
                return Ok(office2);
            case 3:
                var office3 = await _unitOfWork.Employee.GetNonSalesRepresentatives();
                return Ok(office3);
            case 4:
                var office4 = await _unitOfWork.Employee.GetEmployeeBossInformation();
                return Ok(office4);
            case 5:
                var office5 = await _unitOfWork.Employee.GetEmployeeHierarchy();
                return Ok(office5);
            case 6:
                var office6 = await _unitOfWork.Employee.GetEmployeesWithoutOffice();
                return Ok(office6);
            case 7:
                var office7 = await _unitOfWork.Employee.GetEmployeesWithoutClientAndOffice();
                return Ok(office7);
            case 8:
                var office8 = await _unitOfWork.Employee.GetEmployeesWithoutClient();
                return Ok(office8);
            case 9:
                var office9 = await _unitOfWork.Employee.GetEmployeesWithoutClientsAndBoss();
                return Ok(office9);
            case 10:
                var office10 = await _unitOfWork.Employee.GetEmployeesWithoutClients();
                return Ok(office10);
            default:
                return BadRequest("Consulta no válida");
        }
    }
}