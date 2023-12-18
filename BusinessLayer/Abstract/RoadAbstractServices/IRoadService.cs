using EntityLayer.ViewModels;
using EntityLayer.ViewModels.RoadsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.RoadAbstractServices
{
    public interface IRoadService
    {
        Task<RoadViewModel> Add(RoadViewModel roadViewModel);
    }
}
