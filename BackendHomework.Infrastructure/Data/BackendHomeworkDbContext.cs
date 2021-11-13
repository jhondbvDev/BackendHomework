using BackendHomework.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackendHomework.Infrastructure.Data
{
    public class BackendHomeworkDbContext : IdentityDbContext<IdentityUser>
    {
        public BackendHomeworkDbContext(DbContextOptions<BackendHomeworkDbContext> options) : base(options)
        {
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Plate> Plates { get; set; }
    }
}
