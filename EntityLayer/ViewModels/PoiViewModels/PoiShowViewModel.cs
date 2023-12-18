using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ViewModels.PoiViewModels
{
    public class PoiShowViewModel
    {
        public int Id { get; set; }
        public virtual Geometry? geometry { get; set; }
    }
}
