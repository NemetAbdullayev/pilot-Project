using EntityLayer.Concrete.Road;
using EntityLayer.ViewModels.BuildingsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.RoadAbstractServices
{
    public interface IRoadPropertiesService
    {
        Task<RoadProperties> Add(RoadProperties roadProperties);
        Task<RoadProperties> Update(RoadProperties roadProperties);
        Task<RoadProperties> Get(int id);
        Task<List<RoadProperties>> Get();
        Task Delete(int id);
    }
}
