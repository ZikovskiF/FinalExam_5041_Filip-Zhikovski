
using FinalExam_5041.Data;
using FinalExam_5041.Repositories.Interfaces;
using FinalExam_5041.Repositories.Repos;
using Microsoft.EntityFrameworkCore;

namespace FinalExam_5041
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CarClientDbContext>(options =>
            {
                options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyLocalDbFinal;Integrated Security=True");

            });

            builder.Services.AddScoped<IClientRepo, ClientRepo>();
            builder.Services.AddScoped<ICarRepo, CarRepo>();

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
