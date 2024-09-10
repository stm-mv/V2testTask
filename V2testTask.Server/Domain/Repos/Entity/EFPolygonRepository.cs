using Microsoft.EntityFrameworkCore;
using V2testTask.Server.Domain.Repos.Abstract;
using V2testTask.Server.Models;

namespace V2testTask.Server.Domain.Repos.Entity
{
    public class EFPolygonRepository: IPolygonRepository
    {
        private readonly ApplicationContext context;
        public EFPolygonRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public Polygon GetPolygonById(int id)
        {
            return context.Polygons.FirstOrDefault(item => item.Id == id);
        }

        public List<Polygon> GetPolygons()
        {
            return context.Polygons.Include(c => c.Points).ToList();
        }

        public void PostPolygon(Polygon polygon)
        {
            context.Polygons.Add(polygon);
            context.SaveChanges();
        }

		public void DeletePolygon(int id)
		{
            if(context.Polygons.Any(item => item.Id == id))
            {
                var pointsToDelete = context.Points.Where(p => p.Polygon.Id == id).ToList();              
                context.Points.RemoveRange(pointsToDelete);
                context.Polygons.Remove(context.Polygons.First(item => item.Id == id));
                context.SaveChanges();
            }
            else
            {
                throw new NullReferenceException("Полигон не найден");
            }
		}

	}
}
