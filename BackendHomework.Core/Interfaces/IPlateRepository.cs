using BackendHomework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackendHomework.Core.Interfaces
{
    public interface  IPlateRepository: IRepository<Plate>
    {
        Task<IEnumerable<Plate>> GetByUser(int userId);
        Task<IEnumerable<Plate>> GetPublic();
    }
}
