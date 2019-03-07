using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TFCS.API.DomainModels.Dtos;
using TFCS.API.DomainModels.Entities;
using TFCS.API.Repository.Abstraction;

namespace TFCS.API.Repository.Implementation
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        DataContext db;

        public CompanyRepository(DataContext db) : base(db)
        {
            this.db = db;
        }
        public async Task<ICollection<Company>> GetCompanyDetails()
        {
            var companies = await db.Companies.Where(a => a.Active == true).ToListAsync();

            foreach(Company company in companies)
            {
                var surveys = await db.Surveys
                             .Where(a => a.Active == true && a.CompanyId == company.CompanyId)
                             .Include(s => s.SurveyTypes)
                             .ToListAsync();
                company.Surveys = surveys;
            }

            return companies;                                     
        }

        public async Task<Company> GetCompanyDetail(int companyId)
        {
            var company = await db.Companies
                        .FirstOrDefaultAsync(c => c.CompanyId == companyId);

            var surveys = await db.Surveys
                         .Where(a => a.Active == true && a.CompanyId == companyId)
                         .Include(s => s.SurveyTypes)
                         .ToListAsync();

            company.Surveys = surveys;

            return company;                                     
        }   
        
        public async Task<Company> GetCompanySurvey(SurveyPropDto surveyprop)
        {
 
            var company = await db.Companies
                        .Include(surv => surv.Surveys)
                        .Where(c => c.Surveys.Any(sr => sr.CompanyId == surveyprop.CompanyId))
                        .FirstOrDefaultAsync();

                        //var optionTypes = await db.SurveyOptionTypes.ToListAsync();

            var surveys = await db.Surveys
                         .Where(a => a.Active == true && a.CompanyId == surveyprop.CompanyId && a.SurveyId == surveyprop.SurveyId)
                         .Include(s => s.SurveyTypes)
                            .Include(q => q.SurveyQuestions)
                                .ThenInclude(o => o.SurveyOptions)
                                     .ToListAsync();
            company.Surveys = surveys;

 

            return company;
        }

        public async Task<Survey> GetSurveyQuestions(SurveyPropDto surveyprop)
        {
            var survey = await db.Surveys
                         .Include(t => t.SurveyTypes)
                         .Include(c => c.Company)
                         .Include(q => q.SurveyQuestions)                        
                         .ThenInclude(o => o.SurveyOptions)
                         .Where(s => s.CompanyId == surveyprop.CompanyId && s.SurveyId == surveyprop.SurveyId)
                         .FirstOrDefaultAsync();
            return survey;
        }

        public async Task AddSurveyToCompany(Survey survey)
        {

                
                var currentSurvey = await db.Surveys
                                    .Where( c => c.CompanyId == survey.CompanyId && c.SurveyTypeId == survey.SurveyTypeId )
                                    .FirstOrDefaultAsync();
                if(currentSurvey != null)
                {
                // Set it to active if it exists
                    currentSurvey.Active = true;
                    db.Surveys.Update(currentSurvey);
                }
                else
                {
                // Add if it does not exist
                    survey.Active = true;
                    db.Surveys.Add(survey);
                }

        }

        public async Task RemoveSurveyFromCompany(Survey survey)
        {
            var currentSurvey = await db.Surveys
                                .Where(c => c.CompanyId == survey.CompanyId && c.SurveyTypeId == survey.SurveyTypeId)
                                .FirstOrDefaultAsync();
            if (currentSurvey != null)
            {
                // Set it to inactive if it exists
                currentSurvey.Active = false;
                db.Surveys.Update(currentSurvey);
            }

        }

        public async Task<SurveyQuestion> UpdateQuestion(SurveyQuestion surveyQuestion)
        {
            if(surveyQuestion.QuestionId != 0)
            {                
                db.SurveyQuestions.Update(surveyQuestion); 
            }

            return surveyQuestion;
        }

        public async Task<Company> UpdateCompanySurveys(Company company)
        {

            // Find which surveys have been removed
            var currentSurveys = await db.Surveys.Where( s => s.CompanyId == company.CompanyId ).FirstOrDefaultAsync();
            // var removedSurveys = currentSurveys.Where( s => ! company.Surveys.Any(s2 => s2.SurveyTypeId == s.SurveyTypeId) );


            //Loop all the incoming surveys, if it does not exist, then add it to the survey table
            foreach(Survey survey in company.Surveys.ToList()) {
                if( !SurveyExists(survey) )
                {
                    db.Surveys.Add(survey);
                } 
                else
                {
                    //Set to active if the survey exists
                    // var surveyFromDb = db.Surveys
                    //            .Where(s => s.CompanyId == survey.CompanyId && s.SurveyTypeId == survey.SurveyTypeId)
                    //            .FirstOrDefault();
                    // surveyFromDb.Active = true;                    
                }

            }

            // Set the ones that have been removed to inactive
            // foreach(Survey item in removedSurveys)
            // {
            //         var surveyFromDb = db.Surveys
            //                    .Where(s => s.CompanyId == item.CompanyId && s.SurveyTypeId == item.SurveyTypeId)
            //                    .FirstOrDefault();
            //         surveyFromDb.Active = false;   
            // }



            //await db.SaveChangesAsync();


            return company;
        }

        private bool SurveyExists(Survey survey) 
        {
            var exists = false;
            var surveyFromDb = db.Surveys
                               .Where(s => s.CompanyId == survey.CompanyId && s.SurveyTypeId == survey.SurveyTypeId)
                               .FirstOrDefault();
            if (surveyFromDb != null)
                exists = true;
            else
                exists = false;

            return exists;


        }



    }
}