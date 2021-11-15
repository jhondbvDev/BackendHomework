using BackendHomework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendHomework.Core.Interfaces
{
    public interface ILikedPlateService
    {
        Task<IEnumerable<LikedPlate>> GetUserLikedPlates(IPaginationFilter filter, string userId);
        Task<int> GeLikedPlatesCount(string userId);
        Task InsertLikedPlate(Guid plateId, User user);
    }
}
