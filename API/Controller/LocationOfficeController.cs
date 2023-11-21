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
public class LocationOfficeController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LocationOfficeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<LocationOffice>>> Get()
        {
            var entidades = await _unitOfWork.LocationOffices.GetAllAsync();
            return _mapper.Map<List<LocationOffice>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LocationOfficeDto>> Get(int id)
        {
            var entidad = await _unitOfWork.LocationOffices.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<LocationOfficeDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LocationOffice>> Post(LocationOfficeDto LocationOfficeDto)
        {
            var entidad = _mapper.Map<LocationOffice>(LocationOfficeDto);
            this._unitOfWork.LocationOffices.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            LocationOfficeDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = LocationOfficeDto.Id}, LocationOfficeDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LocationOfficeDto>> Put(int id, [FromBody] LocationOfficeDto LocationOfficeDto)
        {
            if(LocationOfficeDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<LocationOffice>(LocationOfficeDto);
            _unitOfWork.LocationOffices.Update(entidades);
            await _unitOfWork.SaveAsync();
            return LocationOfficeDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.LocationOffices.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.LocationOffices.Delete(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }