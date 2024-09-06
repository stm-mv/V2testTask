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
            return context.Polygons.FirstOrDefault(item => item.Id == id); //заглушка
        }

        public List<Polygon> GetPolygons()
        {
            return context.Polygons.ToList();
        }

        public void PostPolygon(Polygon polygon)
        {
            
        }

    }
}
