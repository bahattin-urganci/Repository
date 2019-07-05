using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.Domain.Accounting
{
    public class AccountTransaction 
    {
        public string AccountId { get; set; }
        
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Exchange => Debit - Credit;

        public virtual Account Account { get; set; }
    }
}
