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
    [HttpGet("{consulting}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OfficeDto>> Get(int consulting)
    {
        switch (consulting)
        {
            case 1:
                var result1 = await _unitOfWork.Employee.GetEmployeesWithBossCode7();
                return Ok(result1);

            case 2:
                var result2 = await _unitOfWork.Employee.GetBossInformation();
                return Ok(result2);

            case 3:
                var result3 = await _unitOfWork.Employee.GetNonSalesRepresentatives();
                return Ok(result3);

            case 4:
                var result4 = await _unitOfWork.Employee.GetEmployeeBossInformation();
                return Ok(result4);

            case 5:
                var result5 = await _unitOfWork.Employee.GetEmployeeHierarchy();
                return Ok(result5);

            case 6:
                var result6 = await _unitOfWork.Employee.GetEmployeesWithoutOffice();
                return Ok(result6);

            case 7:
                var result7 = await _unitOfWork.Employee.GetEmployeesWithoutClientAndOffice();
                return Ok(result7);

            case 8:
                var result8 = await _unitOfWork.Employee.GetEmployeesWithoutClient();
                return Ok(result8);

            case 9:
                var result9 = await _unitOfWork.Employee.GetEmployeesWithoutClientsAndBoss();
                return Ok(result9);

            case 10:
                var result10 = await _unitOfWork.Employee.GetEmployeesWithoutClients();
                return Ok(result10);
            case 11:
                var result11 = await _unitOfWork.Employee.GetAllEmplyee();
                return Ok(result11);
            case 12:
                var result12 = await _unitOfWork.Employee.GetAllEmployeeClient();
                return Ok(result12);
            case 13:
                var result13 = await _unitOfWork.Employee.GetEmployeesUnderPatriciaGomezHernandez();
                return Ok(result13);

            case 14:
                var result14 = await _unitOfWork.Employee.GetEmployeesWithoutClient();
                return Ok(result14);

            default:
                return BadRequest("Consulta no válida");
        }

    }
}