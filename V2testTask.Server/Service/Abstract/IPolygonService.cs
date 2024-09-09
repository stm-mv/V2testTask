using V2testTask.Server.Models;

namespace V2testTask.Server.Service.Abstract
{
	public interface IPolygonService
	{
		public bool CheckPointInPolygon(Point point, List<Point> polygonPoints);
	}
}
