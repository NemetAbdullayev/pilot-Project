using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract.DapperInterface
{
    public interface IDapperRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> GetAllItems(string sqlQuery);
        public TEntity GetItem(string sqlQuery);
        public void Execute(string sqlQuery);
    }
}
