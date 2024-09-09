using V2testTask.Server.Models;
using V2testTask.Server.Service.Abstract;

namespace V2testTask.Server.Service
{
    public class PolygonService: IPolygonService
    {
        public bool CheckPointInPolygon(Point point, List<Point> polygonPoints)
        {
			for (int i = 0, j = polygonPoints.Count - 1; i < polygonPoints.Count; j = i++)
			{
				if ((polygonPoints[i].Y > point.Y) != (polygonPoints[j].Y > point.Y) &&
					(point.X < (polygonPoints[j].X - polygonPoints[i].X) * (point.Y - polygonPoints[i].Y) / (polygonPoints[j].Y - polygonPoints[i].Y) + polygonPoints[i].X))
				{
					return true;
				}
			}
			return false;
		}
    }
}
