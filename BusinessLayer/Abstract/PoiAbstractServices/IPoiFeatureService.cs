using EntityLayer.ViewModels;
using EntityLayer.ViewModels.BuildingsViewModels;
using EntityLayer.ViewModels.PoiViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.PoiAbstractServices
{
    public interface IPoiFeatureService
    {
        Task<PoiFeatureListViewModel> Add(PoiFeatureListViewModel featureListViewModel);
        Task<PoiFeatureListViewModel> Update(PoiFeatureListViewModel featureListViewModel);
        Task<PoiFeatureListViewModel> Get(int examId);
        Task<List<PoiFeatureListViewModel>> Get();
        Task Delete(int id);
    }
}
