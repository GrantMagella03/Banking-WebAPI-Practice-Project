using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Banking_WebAPI_Practice_Project.Data;
namespace Banking_WebAPI_Practice_Project {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Banking_WebAPI_Practice_ProjectContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DevDb") ?? throw new InvalidOperationException("Connection string 'Banking_WebAPI_Practice_ProjectContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}