using PawPos.Domain.Accounting;
using System;
using System.Collections.Generic;
using static PawPos.Model.Types;

namespace PawPos.Domain.Ticket
{
    //[WillBeMap("Ticket")]
    public class Ticket : BaseEntity
    {
        public TicketType TicketType { get; set; }
        public string Number { get; set; }
        public bool Closed { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public decimal ExchangeRate { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime LastPaymentDate { get; set; }
        public string Note { get; set; }
        public List<Order> Orders { get; set; }
        public List<TicketAsset> TicketAssets { get; set; }

        public string AccountTransactionOwnerId { get; set; }
        public virtual AccountTransactionOwner AccountTransactionOwner { get; set; }


    }

   
}
