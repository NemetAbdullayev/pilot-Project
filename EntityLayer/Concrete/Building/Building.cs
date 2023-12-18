using EntityLayer.Concrete.Point;
using EntityLayer.ViewModels.BuildingsViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Building
{
    public class Building
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
    
        [JsonProperty("geometry")]
        public  virtual Geometry? geometry { get; set; }
        public int? BuildingFeatureId { get; set; }
        public int? PropertiesId { get; set; }
        public string? IdValue { get; set; }

  

    }
    public class BuildingSaveViewModel
    {
        public int Id { get; set; }

        public BuildingGeometryViewModel? geometry { get; set; }
        public string? idValue { get; set; }
    }

}
