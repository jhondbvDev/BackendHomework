using BackendHomework.Core.Entities;
using BackendHomework.Core.Interfaces;
using BackendHomework.Infrastructure.Data;
using BackendHomework.Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BackendHomework.Infrastructure.Repositories
{
    public class PlateRepository : BaseRepository<Plate>, IPlateRepository
    {
        public PlateRepository(BackendHomeworkDbContext _context)
            : base(_context)
        {

        }

        public IQueryable<Plate> GetPlatesByUserId(int pageNumber, int pageSize, string userId) 
        {
            var pageFilter = new PaginationFilter(pageNumber, pageSize);

            return _entities
                .Where(e => e.User.Id == userId)
                .Skip((pageFilter.PageNumber - 1) * pageFilter.PageSize)
                .Take(pageFilter.PageSize).AsQueryable();
        }

        public async Task<int> GetPrivateCount(string userId)
        {
            return await _entities.Where(p=>p.UserId == userId).CountAsync();
        }

        public  IQueryable<Plate> GetPublicPlates(int pageNumber, int pageSize)
        {
            var pageFilter = new PaginationFilter(pageNumber, pageSize);

            return _entities
                .Where(p => string.IsNullOrEmpty(p.UserId))
                .Skip((pageFilter.PageNumber - 1) * pageFilter.PageSize)
                .Take(pageFilter.PageSize).AsQueryable();
        }

        public async Task<int> GetPublicCount()
        {
            return await _entities.Where(p => string.IsNullOrEmpty(p.UserId)).CountAsync();
        }
    }
}
