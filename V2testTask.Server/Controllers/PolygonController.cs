using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using V2testTask.Server.Domain.Repos;
using V2testTask.Server.Models;
using V2testTask.Server.Service.Abstract;

namespace V2testTask.Server.Controllers
{
    [ApiController]
	[Route("api/[controller]/[action]")]
	public class PolygonController : ControllerBase
    {
        private readonly ILogger<PolygonController> _logger;
        private readonly DataMananger dataMananger;
		private readonly IPolygonService polygonService;
        public PolygonController(DataMananger dataMananger, ILogger<PolygonController> logger, IPolygonService polygonService)
        {
            this.dataMananger = dataMananger;
            _logger = logger;
			this.polygonService = polygonService;
        }

		[ProducesResponseType(typeof(Polygon), (int)HttpStatusCode.OK)]
		[HttpGet("{id:int}")]
		public IActionResult GetPolygon(int id)
        {
            var result = dataMananger.PolygonRepository.GetPolygonById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
		}

		[ProducesResponseType(typeof(List<Polygon>), (int)HttpStatusCode.OK)]
		[HttpGet]
		public IActionResult GetPolygons()
		{
			var result = dataMananger.PolygonRepository.GetPolygons();
			if (result == null)
			{
				return NotFound();
			}
			return Ok(result);
		}

		[HttpPost]
		public IActionResult PostPolygon(Polygon polygon)
		{
			try
			{
				dataMananger.PolygonRepository.PostPolygon(polygon);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			return Ok();
		}
		[HttpDelete("{id:int}")]
		public IActionResult DeletePolygon(int id)
		{
			try
			{
				dataMananger.PolygonRepository.DeletePolygon(id);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			return Ok();
		}

		[HttpPost]
		public IActionResult CheckPointInPolygon(PolygonWithPoint polygon)
		{
			try
			{
				if (polygon.polygon == null || polygon.point == null)
				{
					return BadRequest("Отсутвуют данные для расчета");
				}
				
				var result = polygonService.CheckPointInPolygon(polygon.point, polygon.polygon.Points);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

	}
}
