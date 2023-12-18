using Castle.Components.DictionaryAdapter;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Point
{
    public class Poi
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string? type { get; set; }
        [JsonProperty("geometry")]
        public virtual Geometry? geometry { get; set; }
        public int? PoiFeatureId { get; set; }
        public int? PropertiesId { get; set; }
        public string? IdValue { get; set; }
    }
}
