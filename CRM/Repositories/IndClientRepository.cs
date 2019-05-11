using CRM.Models;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;
using Dapper;

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
    }

}
