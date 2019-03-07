using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFCS.API.DomainModels.Entities;
using TFCS.API.Repository.Abstraction;
using TFCS.API.Repository;

namespace TFCS.API.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Survey> SurveyRepo { get; }
        IRepository<Company> CompanyRepo { get; }
        IRepository<SurveyType> SurveyTypeRepo { get; }
        IRepository<StandardMenuItem> StandardMenuItemsRepo { get; }

        IRepository<SurveyQuestion> SurveyQuestionRepo { get; }

        IRepository<SurveyOptionType> SurveyOptionTypeRepo { get; }

        IRepository<SurveyOption> SurveyOptionRepo { get; }

        ICompanyRepository CompanyDetailedRepo { get; }
        Task<int> SaveChanges();
    }
}
