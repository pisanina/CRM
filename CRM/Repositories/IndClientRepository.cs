using CRM.Models;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;
using Dapper;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Types;

namespace CRM.Repositories
{
    public class IndClientRepository : IndividualClientRepository
    {

        public void AddIndividualClient(IndividualClient individualClient)
        {

            using (OracleConnection SQLConnect =
         new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {

                SQLConnect.Execute("Add_IndividualClient",
                new
                {
                    IC_Name = individualClient.Name
                ,
                    IC_EMail = individualClient.EMail
                ,
                    IC_Street = individualClient.Street
                ,
                    IC_City = individualClient.Street
                ,
                    IC_PostalCode = individualClient.PostalCode
                }, commandType: CommandType.StoredProcedure);
            }

        }

        public void DeleteIndividualClient(int id)
        {
            using (OracleConnection SQLConnect =
                 new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                SQLConnect.Execute("Delete_IndividualClient",
                new
                {
                    IC_ID = id
                }, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<IndividualClient> ListOfIndividualClient()
        {
            using (OracleConnection SQLConnect =
                 new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                var p = new OracleDynamicParameters();
                p.Add("p_clients", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);

                var myRefcurs = SQLConnect.Query<IndividualClient>("System.ClientsList", param : p, 
                    commandType: CommandType.StoredProcedure);
                return myRefcurs;
            }
        }

        public IndividualClient DetailsOfIndividualClient(int id)
        {
            using (OracleConnection SQLConnect =
                 new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                var p = new OracleDynamicParameters();

                p.Add("p_clientID", dbType: OracleDbType.Int32, direction: ParameterDirection.Input, value : id);
                p.Add("p_client", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
               

                var myRefcurs = SQLConnect.QueryFirstOrDefault<IndividualClient>("System.ClientDetails", param : p,
                    commandType: CommandType.StoredProcedure);
                return myRefcurs;
            }
        }

        public void UpdateOfIndividualClient(ChangeClient changedClient)
        {
            using (OracleConnection SQLConnect =
                 new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                var p = new OracleDynamicParameters();
                p.Add("p_id", dbType: OracleDbType.Varchar2, direction: ParameterDirection.Input, value: changedClient.ID);
                p.Add("p_name", dbType: OracleDbType.Varchar2, direction: ParameterDirection.Input, value: changedClient.Name);
                p.Add("p_email", dbType: OracleDbType.Varchar2, direction: ParameterDirection.Input, value: changedClient.EMail);
                p.Add("p_street", dbType: OracleDbType.Varchar2, direction: ParameterDirection.Input, value: changedClient.Street);
                p.Add("p_city", dbType: OracleDbType.Varchar2, direction: ParameterDirection.Input, value: changedClient.City);
                p.Add("p_zip", dbType: OracleDbType.Varchar2, direction: ParameterDirection.Input, value: changedClient.PostalCode);
                
                SQLConnect.Execute("System.ClientUpdate", param : p,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }

}
