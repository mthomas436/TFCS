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
        private IRepository<VehicleMake> _MakeRepo;
        private IRepository<Company> _CompanyRepo;
        private IRepository<SurveyType> _SurveyTypeRepo;
        private IRepository<StandardMenuItem> _StandardMenuItemRepo;

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


        public IRepository<VehicleMake> VehicleMakeRepo
        {
            get
            {
                if (_MakeRepo == null)
                {
                    _MakeRepo = new Repository<VehicleMake>(_db);
                }
                return _MakeRepo;
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
