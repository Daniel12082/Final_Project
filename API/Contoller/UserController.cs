using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace API.Contoller
{
    public class UserController: BaseController
    {
        private readonly JardineriaContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<bool>> Register(UserDto request)
        {
            try
            {
                var existingUser = await _unitOfWork.User.GetUserByEmailAsync(request.email);

                if (existingUser != null)
                {
                    BadRequest("El usuario ya está registrado");
                }

                var newUser = new User
                {
                    email = request.email,
                    PasswordHash = request.password
                };

                this._unitOfWork.User.Add(newUser);
                await this._unitOfWork.SaveAsync();

                return Ok(); // Devuelve true si el usuario se registra correctamente
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, false); // Envía falso en caso de error
            }
        }
        
        [HttpPost("Login")]
        public async Task<bool> Login(UserDto request)
        {
            try
            {
                var userRepository = _unitOfWork.User;

                var user = await userRepository.GetUserByEmailAsync(request.email);

                if (user == null)
                {
                    return false;
                }

                bool passwordMatches=(request.password == user.PasswordHash);

                return passwordMatches;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        }

}