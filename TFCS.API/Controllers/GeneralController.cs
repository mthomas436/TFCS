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
 
    public class GeneralController : ControllerBase
    {
        private readonly IUnitOfWork _uw;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public GeneralController(IUnitOfWork uw,  IMapper mapper)
        {
            _uw = uw;
            _mapper = mapper;
        }

        [HttpGet("getcompaniesdetails", Name = "GetCompaniesDetails")]
        public async Task<IActionResult> GetCompaniesDetails()
        {

            var companies = await _uw.CompanyDetailedRepo.GetCompanyDetails();
            var companiesToReturn = _mapper.Map<ICollection<CompanyForMenuDto>>(companies);

            return Ok(companiesToReturn);
        }

        [HttpGet("getmenuitems", Name = "GetMenuItems")]
        public async Task<IActionResult> GetMenuItems()
        {

            var companies = await _uw.CompanyDetailedRepo.GetCompanyDetails();
            var companiesToReturn = _mapper.Map<ICollection<CompanyForMenuDto>>(companies);

            return Ok(companiesToReturn);
        }        

    }
}