using EntityLayer.Concrete.Road;
using EntityLayer.ViewModels.RoadsViewModel;
using EntityLayer.ViewModels.RoadsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.RoadAbstractServices
{
    public interface IRoadFeautreService
    {
        Task<RoadFeatureListViewModel> Add(RoadFeatureListViewModel roadRootViewModel);
        Task<RoadFeatureViewModel> Update(RoadFeatureViewModel roadRootViewModel);
        Task<RoadFeatureViewModel> Get(int id);
        Task<List<RoadFeatureViewModel>> Get();
        Task Delete(int id);
    }
}
