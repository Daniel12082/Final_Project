using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class OfficeController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OfficeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Office>>> Get()
        {
            var entidades = await _unitOfWork.Offices.GetAllAsync();
            return _mapper.Map<List<Office>>(entidades);
        }

        /*[HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OfficeDto>> Get(int id)
        {
            var entidad = await _unitOfWork.Offices.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<OfficeDto>(entidad);
        }*/

        [HttpGet("{consulting}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OfficeDto>> Get(int consulting)
        {
            switch (consulting)
            {
                case 1:
                    var office = await _unitOfWork.Offices.GetCities_Offices();
                    return Ok(office);

                case 2:
                    var office2 = await _unitOfWork.Offices.GetPais_Cities_Offices();
                    return Ok(office2);

                case 3:
                    var office3 = await _unitOfWork.Offices.GetClient_Offices();
                    return Ok(office3);

                case 4:
                    var office4 = await _unitOfWork.Offices.GetNotFrutales_Offices();
                    return Ok(office4);

                case 5:
                    var office5 = await _unitOfWork.Offices.GetNotClient_Offices();
                    return Ok(office5);

                case 6:
                    var office6 = await _unitOfWork.Offices.GetCities_Employees_Offices();
                    return Ok(office6);

                default:
                    return BadRequest("Consulta no válida");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Office>> Post(OfficeDto OfficeDto)
        {
            var entidad = _mapper.Map<Office>(OfficeDto);
            this._unitOfWork.Offices.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            OfficeDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = OfficeDto.Id}, OfficeDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OfficeDto>> Put(int id, [FromBody] OfficeDto OfficeDto)
        {
            if(OfficeDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<Office>(OfficeDto);
            _unitOfWork.Offices.Update(entidades);
            await _unitOfWork.SaveAsync();
            return OfficeDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.Offices.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.Offices.Delete(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }