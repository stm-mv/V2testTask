using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace V2testTask.Server.Models
{
    public class Point
    {
        [Column("point_id")]
        [JsonIgnore]
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        [Column("PolygonId")]
        [JsonIgnore]
        public int polygonID { get; set; }
        [JsonIgnore]
        public Polygon? Polygon { get; set; }
    }

    public class Polygon
    {
        [Column("polygon_id")]
        [JsonIgnore]
        public int Id { get; set; }
        [Column("polygon_name")]
        public string Name { get; set; }
        [JsonPropertyName("points")]
        public List<Point> Points { get; set; }
    }

    public class PolygonWithPoint
    {
		public Polygon polygon { get; set; }
		public Point point { get; set; }
    }

}
