﻿using Microsoft.EntityFrameworkCore;
using TaskPlanner.Models;

namespace TaskPlanner.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
