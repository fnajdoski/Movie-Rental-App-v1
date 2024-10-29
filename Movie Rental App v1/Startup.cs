using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using MovieRentalApp.Data;
using MovieRentalApp.Repositories;
using MovieRentalApp.Services;

namespace MovieRentalApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MovieRentalContext>(options =>
                options.UseSqlServer("YourConnectionStringHere"));

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IMovieService, MovieService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
