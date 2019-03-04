using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TFCS.API.DomainModels.Dtos;
using TFCS.API.Repository;

namespace TFCS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork uw;

        public SurveyController(IUnitOfWork uw, IMapper mapper)
        {
            this.uw = uw;
            this.mapper = mapper;
        }

        [HttpPost("getcompanysurvey", Name = "GetCompanySurvey")]
        public async Task<IActionResult> GetCompanySurvey(SurveyPropDto surveyprop)
        {
            if (surveyprop.CompanyId == 0)
                return NotFound();

            var company = await uw.CompanyDetailedRepo.GetCompanySurvey(surveyprop);
            return Ok(company);
        }

        
    }
}