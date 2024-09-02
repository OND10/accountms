using AccountingManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Application.ViewModels
{
    public class AccountTransactionViewModel
    {
        public int TransactionAccountId { get; set; }
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public decimal Amount { get; set; }
        public bool IsDebit { get; set; }
    }
}
