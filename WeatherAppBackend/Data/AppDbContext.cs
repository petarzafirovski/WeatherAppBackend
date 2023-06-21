﻿using Microsoft.EntityFrameworkCore;
using WeatherAppBackend.Models;

namespace WeatherAppBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(prop=>prop.Email)
                .IsUnique();
        }
    }
}
