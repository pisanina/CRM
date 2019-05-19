using CRM.Models;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;
using Dapper;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Types;

namespace CRM.Repositories
{
    public class SellerRepository
    {
        public IEnumerable<Seller> ListOfSellers()
        {
            using (OracleConnection SQLConnect =
                 new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                var p = new OracleDynamicParameters();
                p.Add("p_sellers", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);

                var myRefcurs = SQLConnect.Query<Seller>("System.SellersList", param : p,
                    commandType: CommandType.StoredProcedure);
                return myRefcurs;
            }
        }
        public void AddSeller(Seller newSeller)
        {

            using (OracleConnection SQLConnect =
         new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {

                SQLConnect.Execute("Add_Seller",
                new
                {
                    IC_Name = newSeller.Name
                
                }, commandType: CommandType.StoredProcedure);
            }

        }


    }
}