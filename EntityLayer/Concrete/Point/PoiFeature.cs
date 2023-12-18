
using Castle.Components.DictionaryAdapter;
using EntityLayer.ViewModels;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Point
{ 
    public class PoiFeature
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string? type { get; set; }
        public virtual List<Poi> features { get; set; }

    }
}
