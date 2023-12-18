using EntityLayer.ViewModels.PoiViewModels;

namespace BusinessLayer.Abstract.PoiAbstractServices
{
    public interface IPoiService
    {
        Task<PoiViewModel> Add(PoiViewModel poiViewModel);
        Task<PoiViewModel> Update(PoiViewModel poiViewModel);
        Task<PoiViewModel> Get(int id);
        Task<List<PoiViewModel>> Get();
        Task Delete(int id);
    }
}
