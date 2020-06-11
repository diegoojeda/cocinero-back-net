using System;
using System.Collections.Generic;
using ElCocineroBack.Domain.Author;
using ElCocineroBack.Domain.Ingredient;
using ElCocineroBack.Domain.Recipe;
using ElCocineroBack.Domain.Recipe.RecipeIngredient;
using ElCocineroBack.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;

namespace ElCocineroBack.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<RecipeState> Recipes { get; set; }
        public DbSet<AuthorState> Authors { get; set; }

        public DbSet<IngredientState> Ingredients { get; set; }

        public DbSet<RecipeIngredientState> RecipeIngredients { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<RecipeState>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Recipes)
                .HasForeignKey(p => p.AuthorId);

            modelBuilder
                .Entity<RecipeIngredientState>()
                .HasKey(x => new {x.RecipeId, x.IngredientId});

            modelBuilder.Entity<IngredientState>().HasData(IngredientsSeeding.GetAllIngredients());
            base.OnModelCreating(modelBuilder);
        }
    }
}