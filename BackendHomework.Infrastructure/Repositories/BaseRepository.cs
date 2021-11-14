using BackendHomework.Core.Entities;
using BackendHomework.Core.Interfaces;
using BackendHomework.Infrastructure.Data;
using BackendHomework.Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendHomework.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly BackendHomeworkDbContext _context;
        protected DbSet<T> _entities;
        public BaseRepository(BackendHomeworkDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable<T>();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task Add(T entity)
        {
            _entities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await GetById(id);
            _entities.Remove(entity);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(T entity)
        {
            _entities.Update(entity);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<int> GetCount()
        {
            return await _entities.CountAsync();
        }

    }
}
