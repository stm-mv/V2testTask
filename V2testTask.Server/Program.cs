using Microsoft.EntityFrameworkCore;
using V2testTask.Server.Domain;
using V2testTask.Server.Domain.Repos;
using V2testTask.Server.Domain.Repos.Abstract;
using V2testTask.Server.Domain.Repos.Entity;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddTransient<IPolygonRepository, EFPolygonRepository>();
builder.Services.AddTransient<DataMananger>();

builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
