using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using V2testTask.Server.Models;

namespace V2testTask.Server.Domain
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Polygon> Polygons { get; set; } = null!;
        public DbSet<Point> Points { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {           
        }
    }
}
