using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFCS.API.DomainModels.Entities;
using TFCS.API.Repository.Abstraction;

namespace TFCS.API.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _db;

        public Repository(DbContext db)
        {
            _db = db;
        }
        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        public void DeleteById(object Id)
        {
            T entity = _db.Set<T>().Find(Id);
            if (entity != null)
                _db.Set<T>().Remove(entity);
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(object Id)
        {
            return await _db.Set<T>().FindAsync(Id);
        }

        public void Update(T entity)
        {
            _db.Set<T>().Update(entity);
        }
 
    }
}
