using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Building
{
    public class BuildingProperties
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string? building { get; set; }
        public string? geotype { get; set; }
        public int? index { get; set; }

        [JsonProperty("addr:city")]
        public string? addrcity { get; set; }

        [JsonProperty("addr:housenumber")]
        public string? addrhousenumber { get; set; }

        [JsonProperty("addr:street")]
        public string? addrstreet { get; set; }

        [JsonProperty("building:levels")]
        public string? buildinglevels { get; set; }

        [JsonProperty("addr:country")]
        public string? addrcountry { get; set; }
        public string? leisure { get; set; }
        public string? name { get; set; }

        [JsonProperty("opening_hours:covid19")]
        public string? opening_hourscovid19 { get; set; }

        [JsonProperty("addr:postcode")]
        public string? addrpostcode { get; set; }
        public string? amenity { get; set; }

        [JsonProperty("bath:open_air")]
        public string? bathopen_air { get; set; }

        [JsonProperty("bath:sand_bath")]
        public string? bathsand_bath { get; set; }
        public string? charge { get; set; }
        public string? fee { get; set; }
        public string? opening_hours { get; set; }

        [JsonProperty("payment:cash")]
        public string? paymentcash { get; set; }

        [JsonProperty("payment:mastercard")]
        public string? paymentmastercard { get; set; }

        [JsonProperty("payment:visa")]
        public string ? paymentvisa { get; set; }
    }
}
