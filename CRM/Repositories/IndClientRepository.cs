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
                  var name=new OracleParameter("IC_Name",OracleDbType.Varchar2,
                      individualClient.Name, ParameterDirection.Input);
                  var email=new OracleParameter("IC_EMail",OracleDbType.Varchar2,
                      individualClient.EMail, ParameterDirection.Input);
                  var street=new OracleParameter("IC_Street",OracleDbType.Varchar2,
                      individualClient.Street, ParameterDirection.Input);
                  var city=new OracleParameter("IC_City",OracleDbType.Varchar2,
                      individualClient.City, ParameterDirection.Input);
                  var postalCode=new OracleParameter("IC_PostalCode",OracleDbType.Varchar2,
                      individualClient.PostalCode, ParameterDirection.Input);
                  var typeid=new OracleParameter("IC_TypeID",OracleDbType.Int32,
                      individualClient.TypeId, ParameterDirection.Input);

                  var industryIds = new OracleParameter("CI_IndustryIds",OracleDbType.Int32,
                      individualClient.Industries, ParameterDirection.Input);
                industryIds.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                industryIds.Size = individualClient.Industries.Length;

                
                SQLConnect.Open();


                var com=SQLConnect.CreateCommand();
                com.CommandText = "CRM_Package.Add_IndividualClient";
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(name);
                com.Parameters.Add(email);
                com.Parameters.Add(street);
                com.Parameters.Add(city);
                com.Parameters.Add(postalCode);
                com.Parameters.Add(typeid);
                com.Parameters.Add(industryIds);

                com.ExecuteNonQuery();
            }

        }

        public void DeleteIndividualClient(int id)
        {
            using (OracleConnection SQLConnect =
                 new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                SQLConnect.Execute("System.Delete_IndividualClient",
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

        public IEnumerable<ClientType> ListOfClientTypes()
        {
            using (OracleConnection SQLConnect =
                 new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                var p = new OracleDynamicParameters();
                p.Add("p_types", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);

                var myRefcurs = SQLConnect.Query<ClientType>("System.ClientsTypes1", param : p,
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

        public void UpdateOfIndividualClient(IndividualClient changedClient)
        {
            using (OracleConnection SQLConnect =
               new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                var id=new OracleParameter("p_id",OracleDbType.Int32,
                      changedClient.ID, ParameterDirection.Input);
                var name=new OracleParameter("p_name",OracleDbType.Varchar2,
                      changedClient.Name, ParameterDirection.Input);
                var email=new OracleParameter("p_email",OracleDbType.Varchar2,
                      changedClient.EMail, ParameterDirection.Input);
                var street=new OracleParameter("p_street",OracleDbType.Varchar2,
                      changedClient.Street, ParameterDirection.Input);
                var city=new OracleParameter("p_city",OracleDbType.Varchar2,
                      changedClient.City, ParameterDirection.Input);
                var zip=new OracleParameter("p_zip",OracleDbType.Varchar2,
                      changedClient.PostalCode, ParameterDirection.Input);
                var type=new OracleParameter("p_type",OracleDbType.Int32,
                      changedClient.TypeId, ParameterDirection.Input);

                var industryIds = new OracleParameter("p_IndustryIds",OracleDbType.Int32,
                      changedClient.Industries, ParameterDirection.Input);
                industryIds.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                industryIds.Size = changedClient.Industries.Length;


                SQLConnect.Open();


                var com=SQLConnect.CreateCommand();
                com.CommandText = "CRM_Package.Edit_IndividualClient2";
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(id);
                com.Parameters.Add(name);
                com.Parameters.Add(email);
                com.Parameters.Add(street);
                com.Parameters.Add(city);
                com.Parameters.Add(zip);
                com.Parameters.Add(type);
                com.Parameters.Add(industryIds);

                com.ExecuteNonQuery();
            }
        }
    }

}
