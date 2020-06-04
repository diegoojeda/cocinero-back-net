using System;
using System.Collections.Generic;
using ElCocineroBack.Domain.Author;
using ElCocineroBack.Domain.Recipe;
using Microsoft.EntityFrameworkCore;

namespace ElCocineroBack.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<RecipeState> Recipes { get; set; }
        public DbSet<AuthorState> Authors { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}