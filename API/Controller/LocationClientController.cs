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
public class LocationClientController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LocationClientController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<LocationClient>>> Get()
        {
            var entidades = await _unitOfWork.LocationClients.GetAllAsync();
            return _mapper.Map<List<LocationClient>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LocationClientDto>> Get(int id)
        {
            var entidad = await _unitOfWork.LocationClients.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<LocationClientDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LocationClient>> Post(LocationClientDto LocationClientDto)
        {
            var entidad = _mapper.Map<LocationClient>(LocationClientDto);
            this._unitOfWork.LocationClients.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            LocationClientDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = LocationClientDto.Id}, LocationClientDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LocationClientDto>> Put(int id, [FromBody] LocationClientDto LocationClientDto)
        {
            if(LocationClientDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<LocationClient>(LocationClientDto);
            _unitOfWork.LocationClients.Update(entidades);
            await _unitOfWork.SaveAsync();
            return LocationClientDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.LocationClients.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.LocationClients.Delete(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }