using System.Linq;
using System.Security.Principal;
using ElCocineroBack.Domain.Author;
using ElCocineroBack.Domain.Ingredient;
using ElCocineroBack.Domain.Recipe;
using ElCocineroBack.Domain.RecipeIngredient;
using Microsoft.EntityFrameworkCore;
using IIdentity = ElCocineroBack.Domain.ValueObjects.IIdentity;

namespace ElCocineroBack.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<RecipeIngredient>()
                .HasKey(x => new {x.RecipeId, x.IngredientId});
            
            base.OnModelCreating(modelBuilder);
        }
    }
}