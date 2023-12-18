using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Point
{
    public class PoiProperties
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string? amenity { get; set; }
        public string? internet_access { get; set; }
        public string? name { get; set; }
        public string? phone { get; set; }
        public string? website { get; set; }
        public string? geotype { get; set; }
        public int? index { get; set; }

        [JsonProperty("addr:housenumber")]
        public string? addrhousenumber { get; set; }

        [JsonProperty("addr:street")]
        public string? addrstreet { get; set; }
        public string? cuisine { get; set; }

        [JsonProperty("name:en")]
        public string? nameen { get; set; }

        [JsonProperty("name:tr")]
        public string? nametr { get; set; }
        public string? opening_hours { get; set; }

        [JsonProperty("name:ru")]
        public string? nameru { get; set; }

        [JsonProperty("addr:city")]
        public string? addrcity { get; set; }

        [JsonProperty("name:az")]
        public string? nameaz { get; set; }
        public string? brand { get; set; }

        [JsonProperty("brand:wikidata")]
        public string? brandwikidata { get; set; }
        public string? outdoor_seating { get; set; }
        public string? takeaway { get; set; }
        public string? drive_through { get; set; }

        [JsonProperty("diet:vegetarian")]
        public string? dietvegetarian { get; set; }

        [JsonProperty("addr:postcode")]
        public string? addrpostcode { get; set; }

        [JsonProperty("name:fa")]
        public string? namefa { get; set; }
        public string? @operator { get; set; }
        public string? atm { get; set; }
    }
}
