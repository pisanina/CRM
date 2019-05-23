using System.Collections.Generic;

namespace CRM.Models
{
    public class IndividualClient
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int TypeId { get; set; }
        public int[] Industries { get; set; }
    }
}