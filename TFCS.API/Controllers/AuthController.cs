using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TFCS.API.DomainModels.Dtos;
using TFCS.API.DomainModels.Entities;
using TFCS.API.Repository.Abstraction;
using System.Globalization;
using System.Linq;

namespace TFCS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        public AuthController(IConfiguration config, IMapper mapper, UserManager<User> userManager, 
                              SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            _mapper = mapper;
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var userToCreate = _mapper.Map<User>(userForRegisterDto);

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            userToCreate.FirstName = textInfo.ToTitleCase(userToCreate.FirstName);
            userToCreate.LastName = textInfo.ToTitleCase(userToCreate.LastName);

            var result = await _userManager.CreateAsync(userToCreate, userForRegisterDto.Password);

            bool userRoleExists = await _roleManager.RoleExistsAsync("User");
            if(!userRoleExists)
            {
                var newRole = new Role { Name = "User" };
                _roleManager.CreateAsync(newRole).Wait();
            }

            _userManager.AddToRoleAsync(userToCreate, "User").Wait();

            var userToReturn = _mapper.Map<UserForListDto>(userToCreate);

            if(result.Succeeded)
            {
                return Ok(userToReturn);
                //return CreatedAtRoute("GetUser", new { controller = "Users", id = userToCreate.Id }, userToReturn);
            }


            return BadRequest(result.Errors);
        }

/* 
        [HttpPost("updateprofile")]
        public async Task<IActionResult> UpdateProfile(UserForEditDto userForEditDto)
        {
            if (userForEditDto != null)
            {
                var updatedUser = await _repo.UpdateProfile(userForEditDto);
                var updatedUserDto = _mapper.Map<UserForEditDto>(updatedUser);
                return Ok(updatedUserDto);
            }

            return BadRequest("Not found");
        }
*/
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
 
            var user = await _userManager.FindByNameAsync(userForLoginDto.Username);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, userForLoginDto.Password, false);

                if (result.Succeeded)
                {
                    var appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == userForLoginDto.Username.ToUpper());
                    //var userRoles = await _userManager.GetRolesAsync(appUser);
                    var userToReturn = _mapper.Map<UserForListDto>(appUser);

                   // userToReturn.UserRoles = userRoles;
                    //userToReturn.Roles = string.Join(",", userRoles.ToArray()); 

                    return Ok(new
                    {
                        token = GenerateJwtToken(appUser),
                        user = userToReturn
                    });
                }
            }


            return Unauthorized();

        }


        private string GenerateJwtToken(User user)
        {
            var userRoles =  _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                //new Claim(ClaimTypes.Name, userFromRepo.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, (user.FirstName + ' ' + user.LastName)),
                new Claim(ClaimTypes.Role, userRoles.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token); 
        }
    }
}