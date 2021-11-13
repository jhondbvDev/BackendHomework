using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackendHomework.DAL
{
    public class BackendHomeworkDbContext : IdentityDbContext<IdentityUser>
    {
        public BackendHomeworkDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
