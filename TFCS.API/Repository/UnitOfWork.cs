using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFCS.API.DomainModels.Entities;
using TFCS.API.Repository.Abstraction;
using TFCS.API.Repository.Implementation;

namespace TFCS.API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _db;
        private IRepository<Survey> _SurveyRepo;
        private IRepository<SurveyQuestion> _SurveyQuestionRepo;

        private IRepository<Company> _CompanyRepo;
        private IRepository<SurveyType> _SurveyTypeRepo;
        private IRepository<StandardMenuItem> _StandardMenuItemRepo;
        private IRepository<SurveyOptionType> _SurveyOptionTypeRepo;
        private IRepository<SurveyOption> _SurveyOptionRepo;

        ICompanyRepository _companyDetailedRepo;

        public UnitOfWork(DataContext db)
        {
            _db = db;
        }


        public IRepository<Survey> SurveyRepo
        {
            get
            {
                if (_SurveyRepo == null)
                {
                    _SurveyRepo = new Repository<Survey>(_db);
                }
                return _SurveyRepo;
            }
        }


        public IRepository<SurveyQuestion> SurveyQuestionRepo 
        {  
            get
            {
                if (_SurveyQuestionRepo == null)
                {
                    _SurveyQuestionRepo = new Repository<SurveyQuestion>(_db);
                }
                return _SurveyQuestionRepo;
            }            
        }

        public IRepository<SurveyOptionType> SurveyOptionTypeRepo 
        { 
            get
            {
                if (_SurveyOptionTypeRepo == null)
                {
                    _SurveyOptionTypeRepo = new Repository<SurveyOptionType>(_db);
                }
                return _SurveyOptionTypeRepo; 
            }
        
        }

        public IRepository<SurveyOption> SurveyOptionRepo 
        { 
            get
            {
                if (_SurveyOptionRepo == null)
                {
                    _SurveyOptionRepo = new Repository<SurveyOption>(_db);
                }
                return _SurveyOptionRepo; 
            }
        
        }        


        public IRepository<StandardMenuItem> StandardMenuItemsRepo
        { get
            {
                if (_StandardMenuItemRepo == null)
                {
                    _StandardMenuItemRepo = new Repository<StandardMenuItem>(_db);
                }
                return _StandardMenuItemRepo;             
            }
        }

        public IRepository<Company> CompanyRepo
        {
            get
            {
                if (_CompanyRepo == null)
                {
                    _CompanyRepo = new Repository<Company>(_db);
                }
                return _CompanyRepo;
            }
        }


        public IRepository<SurveyType> SurveyTypeRepo
        {
            get
            {
                if (_SurveyTypeRepo == null)
                {
                    _SurveyTypeRepo = new Repository<SurveyType>(_db);
                }
                return _SurveyTypeRepo;
            }
        }

        

        public ICompanyRepository CompanyDetailedRepo
        {
            get
            {
                if (_companyDetailedRepo == null)
                {
                    _companyDetailedRepo = new CompanyRepository(_db);
                }
                return _companyDetailedRepo;
            }
        }


        

        public async Task<int> SaveChanges()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
