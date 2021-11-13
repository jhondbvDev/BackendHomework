using BackendHomework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackendHomework.Core.Interfaces
{
    public interface IPlateService
    {
        Task<Plate> GetPlate(int id);
        IEnumerable<Plate> GetPlates();
        IEnumerable<Plate> GetPlatesByUserId(int userId);
        IEnumerable<Plate> GetPublicPlates();

        Task InsertPlate(Plate plate);
        Task<bool> UpdatePlate(Plate plate);
        Task<bool> DeletePlate(Plate plate);



    }
}
