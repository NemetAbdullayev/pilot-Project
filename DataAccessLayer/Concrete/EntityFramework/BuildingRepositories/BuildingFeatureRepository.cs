using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete.Building;
using DataAccessLayer.Abstract.BuildingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework.BuildingRepositories
{
    public class BuildingFeatureRepository : GenericRepository<BuildingFeature>, IBuildingFeatureRepository
    {
        public BuildingFeatureRepository(DatabaseContext dataContext) : base(dataContext)
        {
        }
    }
}
