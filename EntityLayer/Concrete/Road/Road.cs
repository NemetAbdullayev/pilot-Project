using EntityLayer.Concrete.Point;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Road
{
    public class Road
    {
        public int Id { get; set; }
        public string? type { get; set; }
        [JsonProperty("geometry")]
        public virtual Geometry? geometry { get; set; }
        public int? RoadFeatureId { get; set; }
        public int? PropertiesId { get; set; }
        public string? IdValue { get; set; }
    }
}
