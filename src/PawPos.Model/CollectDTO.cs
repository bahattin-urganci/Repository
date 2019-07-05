using System;
using System.Collections.Generic;
using System.Text;
using static PawPos.Model.Types;

namespace PawPos.Model
{
    public class CollectDTO
    {
        public string TicketId { get; set; }
        public decimal Amount { get; set; }
        public string AccountId { get; set; }
        public CollectType CollectType { get; set; }
    }
}
