using Dapper;
using DataAccessLayer.Abstract.DapperInterface;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete.Building;
using EntityLayer.DapperContext;
using Microsoft.Data.SqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework.DapperRepository
{
    public class DapperRepository<TEntity> : IDapperRepository<TEntity> where TEntity : class
    {

        private readonly DataContext _dataContext;


        NpgsqlConnection conn;

        public DapperRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            conn = new NpgsqlConnection(_dataContext.GetConnectionString());

        }


        public IEnumerable<TEntity> GetAllItems(string sqlQuery)
        {
            try
            {



                return conn.Query<TEntity>(sqlQuery);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public TEntity GetItem(string sqlQuery)
        {
            try
            {

                return conn.QueryFirstOrDefault<TEntity>(sqlQuery);

            }
            catch (Exception)
            {

                return null;
            }

        }

        public void Execute(string sqlQuery)
        {
            try
            {
                conn.Execute(sqlQuery);

            }
            catch (Exception)
            {

                throw;
            }


        }




    }
}