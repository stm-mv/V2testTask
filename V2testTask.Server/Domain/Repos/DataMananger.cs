using V2testTask.Server.Domain.Repos.Abstract;

namespace V2testTask.Server.Domain.Repos
{
    public class DataMananger
    {
        public IPolygonRepository PolygonRepository { get; set; }
        public DataMananger(IPolygonRepository polygonRepository) 
        {
            PolygonRepository = polygonRepository;
        }
    }
}
