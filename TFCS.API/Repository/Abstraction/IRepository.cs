using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TFCS.API.Repository.Abstraction
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        Task<ICollection<T>> GetAll();
        Task<T> GetById(object Id);
        void DeleteById(object Id);
    }
}
