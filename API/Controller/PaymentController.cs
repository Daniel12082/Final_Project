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
public class PaymentController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Payment>>> Get()
        {
            var entidades = await _unitOfWork.Payment.GetAllAsync();
            return _mapper.Map<List<Payment>>(entidades);
        }

        [HttpGet("{consulting}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaymentDto>> Get(int consulting)
        {
            switch (consulting)
            {
                case 1:
                    var order = await _unitOfWork.Payment.GetPayments();
                    return Ok(order);
                case 2:
                    var order2 = await _unitOfWork.Payment.GetMethods();
                    return Ok(order2);
                default:
                    return BadRequest("Consulta no válida");
            }
        }
    }