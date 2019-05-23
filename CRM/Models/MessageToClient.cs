using System;

namespace CRM.Models
{
    public class MessageToClient
    {
        public int ID { get; set; }
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public int ClientId { get; set; }
        public string Message { get; set; }
        public DateTime MessageDate { get; set; }
        public string MessageDateFormatted
        {
            get { return MessageDate.ToString("dd/MM/yyyy"); }
        }
    }
}