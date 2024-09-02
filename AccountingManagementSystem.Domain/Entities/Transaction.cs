using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Domain.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string TransactionType { get; set; } // Type of transaction, e.g., payment, receipt
        public string ReferenceNumber { get; set; } // External reference for the transaction
        public ICollection<TransactionAccount> TransactionAccounts { get; set; } // Many-to-many relationship with Accounts
        //public ICollection<LedgerEntry> LedgerEntries { get; set; }
    }
}
