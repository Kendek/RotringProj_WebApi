
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using RotringWebApi2._0.Entities;

namespace RotringWebApi2._0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddEntityFrameworkMySQL()
                .AddDbContext<RotringContext>(options => 
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
#pragma warning restore CS8604 // Possible null reference argument.

                });
                

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
