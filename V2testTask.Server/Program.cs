using Microsoft.EntityFrameworkCore;
using V2testTask.Server.Domain;
using V2testTask.Server.Domain.Repos;
using V2testTask.Server.Domain.Repos.Abstract;
using V2testTask.Server.Domain.Repos.Entity;
using V2testTask.Server.Service.Abstract;
using V2testTask.Server.Service;

namespace V2testTask.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("appsettings.json");

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddScoped<IPolygonService, PolygonService>();

            builder.Services.AddTransient<IPolygonRepository, EFPolygonRepository>();
            builder.Services.AddTransient<DataMananger>();

            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options => options.AddPolicy("MainCorsSettings", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod())
               );

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseCors("MainCorsSettings");

            //app.UseAuthorization();

            app.MapControllers();

            //app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
