using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFCS.API.DomainModels.Dtos;
using TFCS.API.DomainModels.Entities;

namespace TFCS.API.Repository.Abstraction
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
        Task<User> Get(int id);
        Task<ICollection<User>> Get();

        Task<User> UpdateProfile(UserForEditDto userForEditDto);
    }
}
