using EntityLayer.Concrete.Building;
using EntityLayer.Concrete.Point;
using EntityLayer.ViewModels.PoiViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ViewModels.BuildingsViewModels
{
    public class BuildingViewModel
    {
        public int Id { get; set; }  
        [JsonProperty("geometry")]
        [Column(TypeName = "geometry")]
        public BuildingGeometryViewModel? geometryModel { get; set; }
        public int? PropertiesId { get; set; }
        public int? BuildingFeatureId { get; set; }
        [JsonProperty("id")]
        public string? IdValue { get; set; }
    }
  
    }



