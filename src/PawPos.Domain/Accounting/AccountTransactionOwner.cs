using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PawPos.Domain.Accounting
{
    public class AccountTransactionOwner : BaseEntity
    {
        public AccountTransactionOwner()
        {
            Transactions = new List<AccountTransaction>();
        }
        public List<AccountTransaction> Transactions { get; set; }

        public string[] GetAccountIds() => Transactions.Select(x => x.AccountId).Distinct().ToArray();
    }

    
    
}
