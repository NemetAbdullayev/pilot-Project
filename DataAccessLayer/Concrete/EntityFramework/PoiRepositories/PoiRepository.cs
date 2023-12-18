using DataAccessLayer.Abstract;
using DataAccessLayer.Abstract.PoiInterfaces;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete.Point;

namespace DataAccessLayer.Concrete.EntityFramework.PoiRepositories
{
    public class PoiRepository : GenericRepository<Poi>, IPoiRepository
    {
        public PoiRepository(DatabaseContext dataContext) : base(dataContext)
        {
        }
    }
}
