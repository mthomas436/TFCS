using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TFCS.API.DomainModels.Dtos;
using TFCS.API.DomainModels.Entities;
using TFCS.API.Repository;
using TFCS.API.Repository.Abstraction;

namespace TFCS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _uw;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public UsersController(IUnitOfWork uw, UserManager<User> userManager, IMapper mapper)
        {
            _uw = uw;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet("getusers", Name = "GetUsers")]
        public IActionResult GetUsers()
        {
            var users = _userManager.Users.ToList();
            var usersToReturn = _mapper.Map<ICollection<UserForListDto>>(users);
            //var users = _uw.VehicleMakeRepo.GetAll();

            return Ok(usersToReturn);
        }
    }
}