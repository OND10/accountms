using AccountingManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Application.ViewModels
{
    public class AccountViewModel
    {
        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public decimal OpeningBalance { get; set; }
        public string AccountType { get; set; } // e.g., Asset, Liability, Equity
        public bool IsActive { get; set; }

        public ICollection<TransactionAccount> TransactionAccounts { get; set; } = new List<TransactionAccount>();
    }
}
