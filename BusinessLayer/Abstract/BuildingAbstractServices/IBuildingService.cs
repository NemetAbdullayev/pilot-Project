using EntityLayer.Concrete.Building;
using EntityLayer.ViewModels;
using EntityLayer.ViewModels.BuildingsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.BuildingAbstractServices
{
    public interface IBuildingService
    {
        Task<BuildingViewModel> Add(BuildingViewModel buildingViewModel);
        Task<BuildingViewModel> Update(BuildingViewModel buildingViewModel);
        Task<BuildingViewModel> Get(int id);
        Task<List<BuildingViewModel>> Get();
        Task Delete(int id);
    }
}
