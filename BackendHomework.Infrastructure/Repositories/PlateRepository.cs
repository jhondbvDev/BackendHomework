using BackendHomework.Core.Entities;
using BackendHomework.Core.Interfaces;
using BackendHomework.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace BackendHomework.Infrastructure.Repositories
{
    public class PlateRepository : BaseRepository<Plate>, IPlateRepository
    {
        public PlateRepository(BackendHomeworkDbContext _context)
            : base(_context)
        {

        }

        public IEnumerable<Plate> GetPlatesByUserId(string userId) 
        {
            return _entities.Where(e => e.User == null || e.User.Id == userId).AsEnumerable();
        }

        public IEnumerable<Plate> GetPublicPlates()
        {
            return _entities.AsEnumerable();
        }
    }
}
