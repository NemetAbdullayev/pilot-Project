using EntityLayer.Concrete.Point;
using EntityLayer.ViewModels;
using EntityLayer.ViewModels.PoiViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.PoiAbstractServices
{
    public interface IPoiPropertiesService
    {
        Task<PoiProperties> Add(PoiProperties propertiesViewModel);
        Task<PoiProperties> Update(PoiProperties propertiesViewModel);
        Task<PoiProperties> Get(int examId);
        Task<List<PoiProperties>> Get();
        Task Delete(int id);
    }
}
