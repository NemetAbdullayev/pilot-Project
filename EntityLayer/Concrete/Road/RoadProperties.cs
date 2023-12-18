using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Road
{
    public class RoadProperties
    {
        public int Id { get; set; }
        public string? highway { get; set; }
        public string? name { get; set; }

        [JsonProperty("name:az")]
        public string? nameaz { get; set; }

        [JsonProperty("name:en")]
        public string? nameen { get; set; }

        [JsonProperty("name:ru")]
        public string? nameru { get; set; }
        public string? oneway { get; set; }
        public string? geotype { get; set; }
        public int? index { get; set; }
        public string? alt_name { get; set; }
        public string? junction { get; set; }
        public string? maxwidth { get; set; }
        public string? int_ref { get; set; }
        public string? old_name { get; set; }

        [JsonProperty("old_name:ru")]
        public string? old_nameru { get; set; }
        public string? maxspeed { get; set; }
        public string? surface { get; set; }
        public string? covered { get; set; }
        public string? layer { get; set; }
    }
}
