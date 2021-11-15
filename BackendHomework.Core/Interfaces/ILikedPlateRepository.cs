using BackendHomework.Core.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BackendHomework.Core.Interfaces
{
    public interface ILikedPlateRepository : IRepository<LikedPlate>
    {
        IQueryable<LikedPlate> GetUserLikedPlates(int pageNumber, int pageSize, string userId);
        Task<bool> IsLikedPlateAlreadyCreated(Guid plateId, string userId);
        Task<int> GeLikedPlatesCount(string userId);
    }
}
