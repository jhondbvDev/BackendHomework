using BackendHomework.Core.Entities;
using BackendHomework.Core.Interfaces;
using BackendHomework.Infrastructure.Data;
using System;
using System.Collections.Generic;
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


        public Task<IEnumerable<Plate>> GetPublic()
        {
            throw new NotImplementedException();
        }
    }
}
