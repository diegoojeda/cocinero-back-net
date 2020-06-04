using System.Configuration;
using ElCocineroBack.Domain;
using ElCocineroBack.Domain.Author;
using ElCocineroBack.Domain.Recipe;
using ElCocineroBack.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient(typeof(RecipeService));
            services.AddTransient(typeof(RecipeApplicationService));
            services.AddTransient(typeof(AuthorService));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}