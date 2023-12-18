using Castle.Components.DictionaryAdapter;
using EntityLayer.Concrete;
using EntityLayer.Concrete.Point;
using EntityLayer.ViewModels.BuildingsViewModels;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ViewModels.PoiViewModels
{
    public class PoiFeatureViewModel
    {

        public int Id { get; set; }
        public string? type { get; set; }
        public List<PoiViewModel> features { get; set; }


    }
}
