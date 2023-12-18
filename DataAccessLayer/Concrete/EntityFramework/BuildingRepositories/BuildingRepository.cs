using DataAccessLayer.Abstract;
using DataAccessLayer.Abstract.BuildingInterfaces;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete.Building;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework.BuildingRepositories
{
    public class BuildingRepository : GenericRepository<Building>, IBuildingRepository
    {
        public BuildingRepository(DatabaseContext dataContext) : base(dataContext)
        {
        }
    }
}
