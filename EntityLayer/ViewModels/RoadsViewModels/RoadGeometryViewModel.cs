using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ViewModels.RoadsViewModel
{
    public class RoadGeometryViewModel
    {
        public int Id { get; set; }
        public string type { get; set; }
        public double[,] coordinates { get; set; }
    }
}
