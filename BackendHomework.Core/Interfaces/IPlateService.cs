using BackendHomework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackendHomework.Core.Interfaces
{
    public interface IPlateService
    {
        Task<int> GetCount();
        Task<int> GetPublicCount();
        Task<int> GetPrivateCount(string userId);
        Task<Plate> GetPlate(int id);
         IEnumerable<Plate> GetPlates();
        Task<IEnumerable<Plate>> GetPlatesByUserId(string userId);
        Task<IEnumerable<Plate>> GetPublicPlates(IPaginationFilter filter);

        Task InsertPlate(Plate plate);
        Task<bool> UpdatePlate(Plate plate);
        Task<bool> DeletePlate(Plate plate);



    }
}
