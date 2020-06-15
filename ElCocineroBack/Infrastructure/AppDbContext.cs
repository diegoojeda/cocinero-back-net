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
        public DbSet<RecipeState> Recipes { get; set; }
        public DbSet<AuthorState> Authors { get; set; }

        public DbSet<IngredientState> Ingredients { get; set; }

        public DbSet<RecipeIngredientState> RecipeIngredients { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<RecipeIngredientState>()
                .HasKey(x => new {x.RecipeId, x.IngredientId});
            
            base.OnModelCreating(modelBuilder);
        }
    }
}