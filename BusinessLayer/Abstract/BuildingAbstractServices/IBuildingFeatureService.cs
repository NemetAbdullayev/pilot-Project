using EntityLayer.ViewModels;
using EntityLayer.ViewModels.BuildingsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.BuildingAbstractServices
{
    public interface IBuildingFeatureService
    {
        Task<BuildingFeatureListViewModel> Add(BuildingFeatureListViewModel buildingFeatureViewModel);
        Task<BuildingFeatureViewModel> Update(BuildingFeatureViewModel buildingFeatureViewModel);
        Task<BuildingFeatureViewModel> Get(int id);
        Task<List<BuildingFeatureViewModel>> Get();
        Task Delete(int id);
    }
}
