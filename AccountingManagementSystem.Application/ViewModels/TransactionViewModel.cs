using AccountingManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Application.ViewModels
{
    public class TransactionViewModel
    {
        public int TransactionId { get; set; }
        public string TransactionType { get; set; } // Type of transaction, e.g., payment, receipt
        public string ReferenceNumber { get; set; } // External reference for the transaction
        public ICollection<TransactionAccount> TransactionAccounts { get; set; } = new List<TransactionAccount>();
    }
}
