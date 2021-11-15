using BackendHomework.Core.Entities;
using BackendHomework.Core.Interfaces;
using BackendHomework.Infrastructure.Data;
using BackendHomework.Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BackendHomework.Infrastructure.Repositories
{
    public class LikedPlateRepository : BaseRepository<LikedPlate>, ILikedPlateRepository
    {
        public LikedPlateRepository(BackendHomeworkDbContext _context)
               : base(_context)
        {

        }

        public async Task<bool> IsLikedPlateAlreadyCreated(Guid plateId, string userId)
        {
            var likedPlate = await _entities.Where(e => e.Plate.Id == plateId && e.User.Id == userId).FirstOrDefaultAsync();
            return likedPlate != null;
        }

        public async Task<int> GeLikedPlatesCount(string userId)
        {
            return await _entities.Where(e => e.User.Id == userId).CountAsync();
        }

        public IQueryable<LikedPlate> GetUserLikedPlates(int pageNumber, int pageSize, string userId)
        {
            var pageFilter = new PaginationFilter(pageNumber, pageSize);

            return _entities
                .Where(e => e.User.Id == userId)
                .Include(e => e.Plate)
                .Skip((pageFilter.PageNumber - 1) * pageFilter.PageSize)
                .Take(pageFilter.PageSize);
        }
    }
}
