using CRM.Models;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;
using Dapper;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Types;

namespace CRM.Repositories
{
    public class ActionRepository : IActionRepository
    {
        public void AddAction(Action newAction)
        {

            using (OracleConnection SQLConnect =
                new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {

                SQLConnect.Execute("Add_Message",
                new
                {
                    IC_SellerId = newAction.SellerId
                ,
                    IC_ClientId = newAction.ClientId
                ,
                    IC_Message = newAction.Message


                }, commandType: CommandType.StoredProcedure);
            }

        }

        public IEnumerable<Action> ListOfActions()
        {
            using (OracleConnection SQLConnect =
                 new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                var p = new OracleDynamicParameters();
                p.Add("p_messages", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);

                var myRefcurs = SQLConnect.Query<Action>("System.MessagesList", param : p,
                    commandType: CommandType.StoredProcedure);
                return myRefcurs;
            }
        }

        public IEnumerable<MessageToClient> MessagesForClient(int clientId)
        {
            using (OracleConnection SQLConnect =
                 new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                var p = new OracleDynamicParameters();

                p.Add("p_client", dbType: OracleDbType.Int32, direction: ParameterDirection.Input, value: clientId);
                p.Add("p_messages", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);


                var myRefcurs = SQLConnect.Query<MessageToClient>("System.MessagesListClient", param : p,
                    commandType: CommandType.StoredProcedure);
                return myRefcurs;
            }
        }
    }
}