using BackendHomework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendHomework.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(Guid id);

        Task<int> GetCount();
        Task Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
