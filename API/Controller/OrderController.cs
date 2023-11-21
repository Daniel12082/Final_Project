using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using AutoMapper;
using Core.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class OrderController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            var entidades = await _unitOfWork.Orders.GetAllAsync();
            return _mapper.Map<List<Order>>(entidades);
        }

        /*[HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDto>> Get(int id)
        {
            var entidad = await _unitOfWork.Orders.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<OrderDto>(entidad);
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
                    var order = await _unitOfWork.Orders.GetStatus_Order();
                    return Ok(order);

                case 2:
                    var order2 = await _unitOfWork.Orders.GetDelayed_Order();
                    return Ok(order2);

                case 3:
                    var order3 = await _unitOfWork.Orders.GetAdvanced_Order();
                    return Ok(order3);

                case 4:
                    var order4 = await _unitOfWork.Orders.GetReturned_Order();
                    return Ok(order4);

                case 5:
                    var order5 = await _unitOfWork.Orders.GetDelivered_Order();
                    return Ok(order5);

                case 6:
                    var order6 = await _unitOfWork.Orders.GetStatus_Cantity_Order();
                    return Ok(order6);

                default:
                    return BadRequest("Consulta no válida");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Order>> Post(OrderDto OrderDto)
        {
            var entidad = _mapper.Map<Order>(OrderDto);
            this._unitOfWork.Orders.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            OrderDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = OrderDto.Id}, OrderDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDto>> Put(int id, [FromBody] OrderDto OrderDto)
        {
            if(OrderDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<Order>(OrderDto);
            _unitOfWork.Orders.Update(entidades);
            await _unitOfWork.SaveAsync();
            return OrderDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.Orders.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.Orders.Delete(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }