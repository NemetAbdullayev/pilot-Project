using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Road
{
    public class RoadFeature
    {
        public int Id { get; set; }
        public string type { get; set; }
        public virtual List<Road> features { get; set; }
    }
}
