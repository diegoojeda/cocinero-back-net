using System.Linq;
using System.Security.Principal;
using ElCocineroBack.Domain.Author;
using ElCocineroBack.Domain.Ingredient;
using ElCocineroBack.Domain.Recipe;
using ElCocineroBack.Domain.Recipe.RecipeIngredient;
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
                .Entity<RecipeState>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Recipes)
                .HasForeignKey(p => p.AuthorId);

            modelBuilder
                .Entity<RecipeIngredientState>()
                .HasKey(x => new {x.RecipeId, x.IngredientId});

            modelBuilder
                .Entity<RecipeIngredientState>()
                .HasOne(x => x.Ingredient)
                .WithMany(x => x.Recipes)
                .HasForeignKey(x => x.IngredientId);

            modelBuilder
                .Entity<RecipeIngredientState>()
                .HasOne(x => x.Recipe)
                .WithMany(x => x.Ingredients)
                .HasForeignKey(x => x.RecipeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}