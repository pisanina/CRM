using CRM.Models;
using System.Collections.Generic;

namespace CRM.Repositories
{
    internal interface IActionRepository
    {
        void AddAction(Action newAction);
        IEnumerable<Action> ListOfActions();
        IEnumerable<MessageToClient> MessagesForClient(int clientId);
    }
}