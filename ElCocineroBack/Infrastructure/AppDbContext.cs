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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeState>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Recipes)
                .HasForeignKey(p => p.AuthorId);
            base.OnModelCreating(modelBuilder);
        }
    }
}