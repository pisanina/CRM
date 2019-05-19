using CRM.Models;
using System.Collections.Generic;

namespace CRM.Repositories
{
    internal interface IActionRepository
    {
        void AddAction(Action newAction);
        IEnumerable<Action> ListOfActions();
        IEnumerable<Action> MessagesForClient(int clientId);
    }
}