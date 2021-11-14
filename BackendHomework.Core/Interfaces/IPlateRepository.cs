using BackendHomework.Core.Entities;
using System.Collections.Generic;

namespace BackendHomework.Core.Interfaces
{
    public interface  IPlateRepository: IRepository<Plate>
    {
        IEnumerable<Plate> GetPlatesByUserId(string userId);
        IEnumerable<Plate> GetPublicPlates();
    }
}
