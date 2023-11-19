using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class UserRepository : GenericRepository<User>, IUser
    {
        private readonly JardineriaContext _dbContext;
        public UserRepository(JardineriaContext context) : base(context)
        {
            _dbContext = context;
        }
        public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.email == email);
    }
    }
}