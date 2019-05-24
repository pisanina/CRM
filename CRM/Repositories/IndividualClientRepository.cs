using CRM.Models;
using System.Collections.Generic;

namespace CRM.Repositories
{
    internal interface IndividualClientRepository
    {
        void AddIndividualClient(IndividualClient individualClient);
        void DeleteIndividualClient(int id);
        IEnumerable<IndividualClient> ListOfIndividualClient(string toSearch, int? typeId);
        IndividualClient DetailsOfIndividualClient(int id);
        IEnumerable<ClientType> ListOfClientTypes();
    }
}