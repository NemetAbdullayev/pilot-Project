using DataAccessLayer.Abstract;
using DataAccessLayer.Abstract.RoadInterfaces;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete.Building;
using EntityLayer.Concrete.Road;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework.RoadRepositories
{
    public class RoadPropertiesRepository : GenericRepository<RoadProperties>, IRoadPropertiesRepository
    {
        public RoadPropertiesRepository(DatabaseContext dataContext) : base(dataContext)
        {
        }
    }
}


