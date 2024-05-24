﻿using BookShelf.web.Models.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BookShelf.web.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        
        {
            
        }
        public DbSet<category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>().HasData(
                new category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new category { Id = 2, Name = "SciFic", DisplayOrder = 2 },
                new category { Id = 3, Name = "Thriller", DisplayOrder = 3 }
                );
        }
    }
}