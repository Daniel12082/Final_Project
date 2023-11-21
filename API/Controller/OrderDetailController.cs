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
public class OrderDetailController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderDetailController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> Get()
        {
            var entidades = await _unitOfWork.OrderDetails.GetAllAsync();
            return _mapper.Map<List<OrderDetail>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDetailDto>> Get(int id)
        {
            var entidad = await _unitOfWork.OrderDetails.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<OrderDetailDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDetail>> Post(OrderDetailDto OrderDetailDto)
        {
            var entidad = _mapper.Map<OrderDetail>(OrderDetailDto);
            this._unitOfWork.OrderDetails.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            OrderDetailDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = OrderDetailDto.Id}, OrderDetailDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDetailDto>> Put(int id, [FromBody] OrderDetailDto OrderDetailDto)
        {
            if(OrderDetailDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<OrderDetail>(OrderDetailDto);
            _unitOfWork.OrderDetails.Update(entidades);
            await _unitOfWork.SaveAsync();
            return OrderDetailDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.OrderDetails.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.OrderDetails.Delete(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }