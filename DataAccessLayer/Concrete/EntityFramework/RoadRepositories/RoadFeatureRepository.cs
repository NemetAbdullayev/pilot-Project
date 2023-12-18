using DataAccessLayer.Abstract.RoadInterfaces;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete.Road;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework.RoadRepositories
{
    public class RoadFeatureRepository : GenericRepository<RoadFeature>, IRoadFeauteRepository
    {
        public RoadFeatureRepository(DatabaseContext dataContext) : base(dataContext)
        {
        }
    }
}

