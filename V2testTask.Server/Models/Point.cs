using System.ComponentModel.DataAnnotations.Schema;

namespace V2testTask.Server.Models
{
    public class Point
    {
        [Column("point_id")]
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }

    public class Polygon
    {
        [Column("polygon_id")]
        public int Id { get; set; }
        [Column("polygon_name")]
        public string Name { get; set; }
        public List<Point> Points { get; set; }
    }

    public class PolygonWithPoint
    {
		public Polygon polygon { get; set; }
		public Point point { get; set; }
    }

}
