using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public int id {get; set;}
        public string email {get; set;}
        public string PasswordHash {get; set;}
    }
}