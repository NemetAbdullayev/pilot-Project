using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ViewModels.BuildingsViewModels
{
    public class BuildingGeometryViewModel
    {
        public int Id { get; set; }
        public string type { get; set; }
        public float[,,] coordinates { get; set; }
    }

    }