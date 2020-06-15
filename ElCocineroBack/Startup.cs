using ElCocineroBack.Domain;
using ElCocineroBack.Domain.Author;
using ElCocineroBack.Domain.Ingredient;
using ElCocineroBack.Domain.Recipe;
using ElCocineroBack.Domain.RecipeIngredient;
using ElCocineroBack.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ElCocineroBack
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("AppDbContext"));
            });

            services.AddScoped<IRecipeRepository, EfRecipeRepository>();
            services.AddScoped<IAuthorRepository, EfAuthorRepository>();
            services.AddScoped<IIngredientRepository, EfIngredientRepository>();
            services.AddScoped<IRecipeIngredientRepository, EfRecipeIngredientRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient(typeof(RecipeService));
            services.AddTransient(typeof(RecipeApplicationService));

            services.AddTransient(typeof(AuthorService));
            services.AddTransient(typeof(AuthorApplicationService));

            services.AddTransient(typeof(IngredientService));

            services.AddTransient(typeof(RecipeIngredientService));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseStaticFiles();
        }
    }
}