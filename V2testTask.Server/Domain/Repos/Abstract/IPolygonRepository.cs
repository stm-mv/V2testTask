using V2testTask.Server.Models;

namespace V2testTask.Server.Domain.Repos.Abstract
{
    public interface IPolygonRepository
    {
        Polygon GetPolygonById(int id);
        List<Polygon> GetPolygons();
        void PostPolygon(Polygon polygon);
    }
}
