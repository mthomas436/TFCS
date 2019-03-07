using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TFCS.API.DomainModels.Dtos;
using TFCS.API.DomainModels.Entities;
using TFCS.API.Repository;

namespace TFCS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IUnitOfWork uw;
        private readonly IMapper mapper;
        public QuestionsController(IUnitOfWork uw,  IMapper mapper)
        {
            this.uw = uw;
            this.mapper = mapper;
        }     

        [HttpPost("getsurveyquestions", Name = "GetSurveyQuestions")]
        public async Task<IActionResult> GetSurveyQuestions(SurveyPropDto surveyprop)
        {
            if (surveyprop.CompanyId == 0)
                return NotFound();

            var survey = await uw.CompanyDetailedRepo.GetSurveyQuestions(surveyprop);
            return Ok(survey);
        }  

        [HttpPost("updatesurveyquestion", Name = "UpdateSurveyQuestion")]      
        public async Task<IActionResult> UpdateSurveyQuestion(QuestionForUpdateDto questionForUpdateDto)
        {
            if(questionForUpdateDto.QuestionId > 0)
            {
                var questionFromDb = await uw.SurveyQuestionRepo.GetById(questionForUpdateDto.QuestionId);

                if(questionFromDb != null)
                {                    
                    var questionToUpdate  =  mapper.Map(questionForUpdateDto, questionFromDb);
                    questionToUpdate.ShortQuestionName = questionForUpdateDto.QuestionName;
                    uw.SurveyQuestionRepo.Update(questionToUpdate);
                    await uw.SaveChanges();
                    return Ok(questionToUpdate);
                }

                return NotFound();
            }

            return NotFound();
        }   

        [HttpPost("addsurveyquestion", Name = "AddSurveyQuestion")]   
        public async Task<IActionResult> AddSurveyQuestion(QuestionForInsertDto questionForInsertDto)
        {
            if(questionForInsertDto != null)
            {
                var questionToCreate = mapper.Map<SurveyQuestion>(questionForInsertDto);
                uw.SurveyQuestionRepo.Add(questionToCreate);
                await uw.SaveChanges();
                return Ok(questionToCreate);
            }
            return BadRequest("Question not created");
        }


        [HttpPost("deletequestion", Name = "DeleteQuestion")]   
        public async Task<IActionResult> DeleteQuestion(QuestionForUpdateDto questionForUpdateDto)
        {
            if(questionForUpdateDto != null)
            {
                uw.SurveyQuestionRepo.DeleteById(questionForUpdateDto.QuestionId);
                await uw.SaveChanges();
                return Ok();
            }
            return BadRequest("An error occured");
        } 

        [HttpGet("getoptiontypes", Name = "GetOptionTypes")]
        public async Task<IActionResult> GetOptionTypes()
        {

            var optionTypes = await uw.SurveyOptionTypeRepo.GetAll();

            return Ok(optionTypes);
        }  


        [HttpPost("updateoption", Name = "UpdateOption")]   
        public async Task<IActionResult> UpdateOption(SurveyOption surveyOption)
        {
            if(surveyOption != null)
            {
                uw.SurveyOptionRepo.Update(surveyOption);
                await uw.SaveChanges();
                return Ok(surveyOption);
            }
            return BadRequest("An error occured");
        }      


        [HttpPost("addoption", Name = "AddOption")]   
        public async Task<IActionResult> AddOption(SurveyOption surveyOption)
        {
            if(surveyOption != null)
            {
                uw.SurveyOptionRepo.Add(surveyOption);
                await uw.SaveChanges();
                return Ok(surveyOption);
            }
            return BadRequest("An error occured");
        }  

        [HttpPost("deleteoption", Name = "DeleteOption")]   
        public async Task<IActionResult> DeleteOption(SurveyOption surveyOption)
        {
            if(surveyOption != null)
            {
                uw.SurveyOptionRepo.DeleteById(surveyOption.OptionId);
                await uw.SaveChanges();
                return Ok();
            }
            return BadRequest("An error occured");
        } 

        [HttpPost("updatesurveyinfo", Name = "UpdateSurveyInfo")]   
        public async Task<IActionResult> UpdateSurveyInfo(Survey survey)
        {
            if(survey != null)
            {
                uw.SurveyRepo.Update(survey);
                await uw.SaveChanges();
                return Ok(survey);
            }
            return BadRequest("An error occured");
        } 
             
                         
    }
} 