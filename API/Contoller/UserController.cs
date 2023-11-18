using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Contoller
{
    public class UserController: BaseController
    {
        public static User user = new User();

        [HttpPost("register")]
        public ActionResult<User>  Register(UserDto request)
        {
            string PasswordHasher
                =BCrypt.Net.BCrypt.HashPassword(request.password);
            user.email = request.email;
            user.PasswordHash = PasswordHasher;
            return Ok(user);
        }
        [HttpPost("login")]
        public ActionResult<User>  Login(UserDto request)
        {
            Console.WriteLine(request.email,request.password);
            if(user.email != request.email){
                return BadRequest("User no register");
            }
            if(!BCrypt.Net.BCrypt.Verify(request.password, user.PasswordHash))
            {
                return BadRequest("Password incorrect");
            }
            else{
                return Ok(user);
            }
        }
    }

}