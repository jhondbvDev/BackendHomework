﻿using BackendHomework.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackendHomework.Infrastructure.Data
{
    public class BackendHomeworkDbContext : IdentityDbContext<User>
    {
        public DbSet<Plate> Plates { get; set; }
        public DbSet<LikedPlate> LikedPlates { get; set; }

        public BackendHomeworkDbContext(DbContextOptions<BackendHomeworkDbContext> options) : base(options)
        {
        }
    }
}
