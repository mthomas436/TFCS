using System.Collections.Generic;
using System.Threading.Tasks;
using TFCS.API.DomainModels.Dtos;
using TFCS.API.DomainModels.Entities;

namespace TFCS.API.Repository.Abstraction
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<ICollection<Company>>GetCompanyDetails();

        Task<Company>GetCompanyDetail(int companyId);

        Task<Company> UpdateCompanySurveys(Company company);

        Task AddSurveyToCompany(Survey survey);
        Task RemoveSurveyFromCompany(Survey survey);

        Task<Company> GetCompanySurvey(SurveyPropDto surveyprop);
        Task<Survey> GetSurveyQuestions(SurveyPropDto surveyprop);

        Task<SurveyQuestion> UpdateQuestion(SurveyQuestion surveyQuestion);
    }
}