using CRM.Models;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;
using Dapper;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Types;

namespace CRM.Repositories
{
    public class IndustryRepository
    {

        public IEnumerable<Industry> ListOfIndustries()
        {
            using (OracleConnection SQLConnect =
                 new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                var p = new OracleDynamicParameters();
                p.Add("p_industries", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);

                var myRefcurs = SQLConnect.Query<Industry>("System.IndustriesList", param : p,
                    commandType: CommandType.StoredProcedure);
                return myRefcurs;
            }
        }

        public IEnumerable<int> IndustriesOfClient(int id)
        {
            using (OracleConnection SQLConnect =
                 new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                var p = new OracleDynamicParameters();

                p.Add("p_client", dbType: OracleDbType.Int32, direction: ParameterDirection.Input, value: id);
                p.Add("p_industries", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);


                var myRefcurs = SQLConnect.Query<int>("System.IndustryOfClient1", param : p,
                    commandType: CommandType.StoredProcedure);
                return myRefcurs;
            }
        }
    }
}