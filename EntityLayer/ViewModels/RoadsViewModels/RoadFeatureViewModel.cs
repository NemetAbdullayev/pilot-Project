using EntityLayer.ViewModels.BuildingsViewModels;
using EntityLayer.ViewModels.RoadsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ViewModels.RoadsViewModels
{
    public class RoadFeatureViewModel
    {
        public int Id { get; set; }
        public string type { get; set; }
        public List<RoadViewModel>? features { get; set; }
    }
}
