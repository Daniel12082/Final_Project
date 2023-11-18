using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces;

    public interface IUnitOfWork{
        IBossRepository Bosses { get; }


        Task<int> SaveAsync();
    }

