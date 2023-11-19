using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace API.Controller
{
    public class UserController: BaseController
    {
        private readonly JardineriaContext _dbContext;

        public UserController(JardineriaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public static User user = new User();

        public ActionResult<User> Register(UserDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.password);
            var newUser = new User
            {
                email = request.email,
                PasswordHash = passwordHash
            };

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            return Ok("Bienvenido");
        }
        [HttpPost("login")]
        public ActionResult<User> Login(UserDto request)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.email == request.email);

            if (user == null)
            {
                return BadRequest("User not registered");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.password, user.PasswordHash))
            {
                return BadRequest("Incorrect password");
            }
            else
            {
                return Ok("Registro Exitoso");
            }
        }
    }

}