using BackendHomework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendHomework.Core.Interfaces
{
    public interface IPlateService
    {
        Task<int> GetCount();
        Task<int> GetPublicCount();
        Task<int> GetPrivateCount(string userId);
        Task<Plate> GetPlate(Guid id);
        Task<IEnumerable<Plate>> GetPlatesByUserId(IPaginationFilter filter, string userId);
        Task<IEnumerable<Plate>> GetPublicPlates(IPaginationFilter filter);

        Task InsertPlate(Plate plate);
        Task<bool> UpdatePlate(Plate plate,string userId);
        Task<bool> DeletePlate(Guid plateId, string userId);
        Task<bool> DeleteAllUserPlates(string userId);
    }
}
