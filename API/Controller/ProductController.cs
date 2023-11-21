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
public class ProductController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var entidades = await _unitOfWork.Products.GetAllAsync();
            return _mapper.Map<List<Product>>(entidades);
        }

        /*[HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var entidad = await _unitOfWork.Products.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<ProductDto>(entidad);
        }*/

        [HttpGet("{consulting}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> Get(int consulting)
        {
            switch (consulting)
            {
                case 1:
                    var Product = await _unitOfWork.Products.GetStock_Products();
                    return Ok(Product);

                default:
                    return BadRequest("Consulta no válida");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> Post(ProductDto ProductDto)
        {
            var entidad = _mapper.Map<Product>(ProductDto);
            this._unitOfWork.Products.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            ProductDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = ProductDto.Id}, ProductDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> Put(int id, [FromBody] ProductDto ProductDto)
        {
            if(ProductDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<Product>(ProductDto);
            _unitOfWork.Products.Update(entidades);
            await _unitOfWork.SaveAsync();
            return ProductDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.Products.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.Products.Delete(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }