using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFCS.API.DomainModels.Dtos;
using TFCS.API.DomainModels.Entities;
using TFCS.API.Repository;
using System.Linq;

namespace TFCS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[AllowAnonymous]
    public class AdminController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork uw;
        private readonly RoleManager<Role> roleManager;
        private readonly UserManager<User> userManager;
        private readonly DataContext db;
        public AdminController(IUnitOfWork uw, IMapper mapper, RoleManager<Role> roleManager, 
                               UserManager<User> userManager, DataContext db)
        {
            this.uw = uw;
            this.mapper = mapper;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.db = db;
        }

        [HttpGet("getcompanylist", Name = "GetCompanyList")]
        public async Task<IActionResult> GetCompanyList()
        {
            var companies = await uw.CompanyRepo.GetAll();
            return Ok(companies);
        }

        [HttpGet("getsurveytypes", Name = "GetSurveyTypes")]
        public async Task<IActionResult> GetSurveyTypes()
        {
            var surveytypes = await uw.SurveyTypeRepo.GetAll();
            return Ok(surveytypes);
        }


       [HttpGet("getcompanydetail/{companyid}", Name = "GetCompanyDetail")]
        public async Task<IActionResult> GetCompanyDetail(int? companyid)
        {
            if(companyid == null)
                return NotFound();

            var company = await uw.CompanyDetailedRepo.GetCompanyDetail(companyid.Value);
            return Ok(company);
        }

        [HttpGet("getcompanies", Name = "GetCompanies")]
        public async Task<IActionResult> GetCompanies()
        {

            var companies = await uw.CompanyDetailedRepo.GetCompanyDetails();

            return Ok(companies);
        }


        [HttpGet("getstdmenuitems", Name = "GetStdMenuItems")]
        public async Task<IActionResult> GetStdMenuItems()
        {
            var menuitems = new MenuItemsDto
            {
                Companies = await uw.CompanyDetailedRepo.GetCompanyDetails(),
                StandardSurveyTypes = await uw.SurveyTypeRepo.GetAll(),
                StandardMenuItems = await  uw.StandardMenuItemsRepo.GetAll()
            };

            return Ok(menuitems);
        }


        [HttpPost("updatecompany", Name = "UpdateCompany")]
        public async Task<IActionResult> UpdateCompany(Company company)
        {
            if(company == null)
                return NotFound();

            uw.CompanyRepo.Update(company);    

            await uw.SaveChanges();

            return Ok(company);            
        }    

        [HttpPost("addsurveytocompany", Name = "AddSurveyToCompany")]
        public async Task<IActionResult> AddSurveyToCompany(Survey survey)
        {
            await uw.CompanyDetailedRepo.AddSurveyToCompany(survey);
            await uw.SaveChanges();

            return Ok(uw.CompanyRepo.GetById(survey.SurveyId));
        }

        [HttpPost("removesurveyfromcompany", Name = "RemoveSurveyFromCompany")]
        public async Task<IActionResult> RemoveSurveyFromCompany(Survey survey)
        {
            await uw.CompanyDetailedRepo.RemoveSurveyFromCompany(survey);
            await uw.SaveChanges();

            return Ok(GetCompanyDetail(survey.SurveyId));
        }

        [HttpPost("createrole", Name = "CreateRole")]
        public async Task<IActionResult> CreateRole(RoleToCreateDto role)
        {
            
  
            bool userRoleExists = await roleManager.RoleExistsAsync(role.RoleName);
            if(!userRoleExists)
            {
                var newRole = new Role { Name = role.RoleName };
                roleManager.CreateAsync(newRole).Wait();
            }

           return Ok(roleManager.Roles);
        }

        [HttpGet("getrolelist", Name ="GetRoleList")]
        public async Task<IActionResult> GetRoleList()
        {
            return Ok(roleManager.Roles);
        }
        

        [HttpGet("getuserlist", Name ="GetUserist")]
        public async Task<IActionResult> GetUserist()
        {
            var usersWithRoles = (from user in db.Users
                                  select new
                                  {
                                      Id = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      FirstName = user.FirstName,
                                      lastName = user.LastName,
                                      active = user.Active,
                                      RoleNames = (from userRole in user.UserRoles
                                                   join Role in db.Roles on userRole.RoleId
                                                   equals Role.Id
                                                   select Role.Name).ToList()
                                  }).ToList().Select(p => new UserForListDto()
                                  {
                                      Id = p.Id,
                                      Username = p.Username,
                                      Email = p.Email,
                                      Firstname = p.FirstName,
                                      Lastname = p.lastName,
                                      Active = p.active,
                                      Roles = string.Join(",", p.RoleNames)
                                  });

            return Ok(usersWithRoles);
           // return Ok( mapper.Map<ICollection<UserForListDto>>(userManager.Users) );
        }



        [HttpPost("getsurveyquestions", Name = "GetSurveyQuestions")]
        public async Task<IActionResult> GetSurveyQuestions(SurveyPropDto surveyprop)
        {
            if (surveyprop.CompanyId == 0)
                return NotFound();

            var survey = await uw.CompanyDetailedRepo.GetSurveyQuestions(surveyprop);
            return Ok(survey);
        }

    }
}