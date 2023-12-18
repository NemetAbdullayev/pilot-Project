using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ViewModels.RoadsViewModels
{
    public class SpatialParam : SqlMapper.IDynamicParameters
    {
        string name;
        object val;

        public SpatialParam(string name, object val)
        {
            this.name = name;
            this.val = val;
        }

        public void AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            var sqlCommand = (SqlCommand)command;
            sqlCommand.Parameters.Add(new SqlParameter
            {
                UdtTypeName = "geometry",
                Value = val,
                ParameterName = name
            });
        }
    }
   
    }

