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
public class ClientController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Client>>> Get()
        {
            var entidades = await _unitOfWork.Clients.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<Client>>(entidades));
        }

        [HttpGet("{consulting}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OfficeDto>> Get(int consulting)
        {
            switch (consulting)
            {
                case 1:
                    var office = await _unitOfWork.Clients.GetCitiesOfSpain();
                    return Ok(office);

                case 2:
                    var office2 = await _unitOfWork.Clients.GetClientsWithPaymentsIn2008();
                    return Ok(office2);
                case 3:
                    var office3 = await _unitOfWork.Clients.GetClientsMadridRepresent();
                    return Ok(office3);
                case 4:
                    var office4 = await _unitOfWork.Clients.GetClientAndRepresent();
                    return Ok(office4);
                case 5:
                    var office5 = await _unitOfWork.Clients.GetClientWithOutPayAndRepresent();
                    return Ok(office5);
                default:
                    return BadRequest("Consulta no válida");
            }
        }
    }