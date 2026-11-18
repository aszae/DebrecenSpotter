using DebrecenSpotter.Api.Data;
using DebrecenSpotter.Api.Repositories;
using DebrecenSpotter.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DebrecenSpotter.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));
            builder.Services.AddScoped<ISightGalleryRepository, SightGalleryRepository>();
            builder.Services.AddScoped<ISightRepository, SightRepository>();
            builder.Services.AddScoped<ISpottingRepository, SpottingRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            var app = builder.Build();

            app.UseHttpsRedirection();
            //app.UseHsts();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.EnsureCreated(); 
            }
            app.Run();
        }
    }
}