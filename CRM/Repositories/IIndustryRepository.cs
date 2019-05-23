using CRM.Models;
using System.Collections.Generic;

namespace CRM.Repositories
{
    internal interface IIndustryRepository
    {
        IEnumerable<Industry> ListOfIndustries();
        IEnumerable<Industry> IndustriesOfClient(int id);
    }
}