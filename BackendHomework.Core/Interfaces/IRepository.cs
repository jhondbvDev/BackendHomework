using BackendHomework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackendHomework.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);


        Task Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
    }
}
