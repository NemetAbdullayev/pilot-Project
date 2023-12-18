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
    public class RoadRepository : GenericRepository<Road>, IRoadRepository
    {
        public RoadRepository(DatabaseContext dataContext) : base(dataContext)
        {
        }
    }
}