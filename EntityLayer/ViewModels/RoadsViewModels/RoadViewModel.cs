using EntityLayer.Concrete.Road;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ViewModels.RoadsViewModel
{
    public class RoadViewModel
    {
        public int Id { get; set; }
        public string type { get; set; }
        [JsonProperty("geometry")]
        public RoadGeometryViewModel geometryModel { get; set; }
        public int? PropertiesId { get; set; }
        public int RoadFeatureId { get; set; }
        [JsonProperty("id")]
        public string id { get; set; }
    }
}
