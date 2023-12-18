using EntityLayer.ViewModels.PoiViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ViewModels.BuildingsViewModels
{
    public class BuildingFeatureViewModel
    {
        public int Id { get; set; }
        public string? type { get; set; }
        public List<BuildingViewModel>? features { get; set; }
    }
   

}
