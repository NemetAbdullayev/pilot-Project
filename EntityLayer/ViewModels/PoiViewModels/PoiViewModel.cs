using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ViewModels.PoiViewModels
{
    public class PoiViewModel
    {
        public int Id { get; set; }
        public string type { get; set; }
        [JsonProperty("geometry")]
        public GeometryViewModel geometryModel { get; set; }
        public int PropertiesId { get; set; }
        public int PoiFeatureId { get; set; }
        [JsonProperty("id")]
        public string idValue { get; set; }
    }
   

    }
   


