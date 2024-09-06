using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using V2testTask.Server.Domain.Repos;
using V2testTask.Server.Models;

namespace V2testTask.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PolygonController : ControllerBase
    {
        private readonly DataMananger dataMananger;
        public PolygonController(DataMananger dataMananger)
        {
            this.dataMananger = dataMananger;
        }

        [HttpGet(Name = "GetTest")]
        public IEnumerable<Polygon> GetPolygon()
        {
            return dataMananger.PolygonRepository.GetPolygons();
        }
    }
}
