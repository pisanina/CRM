using CRM.Models;
using System.Collections.Generic;

namespace CRM.Repositories
{
    internal interface ISellerRepository
    {
        IEnumerable<Seller> ListOfSellers();
        void AddSeller(Seller newSeller);
    }
}