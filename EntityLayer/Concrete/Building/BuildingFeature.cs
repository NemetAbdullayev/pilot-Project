using EntityLayer.Concrete.Point;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Building
{
    public class BuildingFeature
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string? type { get; set; }
        public virtual List<Building>? features { get; set; }

    }
}
