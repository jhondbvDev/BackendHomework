using BackendHomework.Core.Entities;
using BackendHomework.Core.Interfaces;
using BackendHomework.Infrastructure.Data;
using BackendHomework.Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendHomework.Infrastructure.Repositories
{
    public class PlateRepository : BaseRepository<Plate>, IPlateRepository
    {
        public PlateRepository(BackendHomeworkDbContext _context)
            : base(_context)
        {

        }

        public Task<IEnumerable<Plate>> GetByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetPrivateCount(string userId)
        {
            return await _entities.Where(p=>p.UserId==userId).CountAsync();
        }

        public  IQueryable<Plate> GetPublic(int pageNumber, int pageSize)
        {
            var pageFilter = new PaginationFilter(pageNumber, pageSize);
            var plates =  _entities
                .Where(p=>string.IsNullOrEmpty(p.UserId))
                .Skip((pageFilter.PageNumber - 1) * pageFilter.PageSize)
                .Take(pageFilter.PageSize).AsQueryable<Plate>();
            return plates;
        }

        public async Task<int> GetPublicCount()
        {
            return await _entities.Where(p => string.IsNullOrEmpty(p.UserId)).CountAsync();
        }
    }
}
