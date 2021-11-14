using BackendHomework.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackendHomework.Infrastructure.Data
{
    public class BackendHomeworkDbContext : IdentityDbContext<User>
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Plate> Plates { get; set; }

        public BackendHomeworkDbContext(DbContextOptions<BackendHomeworkDbContext> options) : base(options)
        {
        }
    }
}
