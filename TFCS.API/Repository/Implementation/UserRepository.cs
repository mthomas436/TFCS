using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFCS.API.DomainModels.Entities;
using TFCS.API.Repository.Abstraction;
using System.Linq;

namespace TFCS.API.Repository.Implementation
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        DataContext db;
        public UserRepository(DataContext db) : base(db)
        {
            this.db = db;
        }


    }
}
