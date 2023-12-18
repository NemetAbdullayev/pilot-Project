using DataAccessLayer.Abstract.PoiInterfaces;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete.Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework.PoiRepositories
{
    public class PoiPropertiesRepository : GenericRepository<PoiProperties>, IPoiPropertiesRepository
    {
        public PoiPropertiesRepository(DatabaseContext dataContext) : base(dataContext)
        {
        }
    }
}