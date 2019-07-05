using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.Domain.Ticket
{
    public class Order
    {
        public OrderProduct Product { get; set; }
        public int Quantity { get; set; }
        public decimal OrderAmount { get; set; }


    }
}
