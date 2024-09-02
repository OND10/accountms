using AccountingManagementSystem.Domain.Entities;
using AccountingManagementSystem.Domain.Interfaces;
using AccountingManagementSystem.Infustracture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Infustracture.Repository
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(AppDbContext context, IUnitofWork unitofWork) : base(context, unitofWork)
        {
        }

        // Implement additional methods specific to Transaction if needed
        public async Task<bool> ValidateTransactionAsync(Transaction transaction)
        {
            var totalDebits = transaction.TransactionAccounts.Where(ta => ta.IsDebit).Sum(ta => ta.Amount);
            var totalCredits = transaction.TransactionAccounts.Where(ta => !ta.IsDebit).Sum(ta => ta.Amount);
            return totalDebits == totalCredits;
        }
    }
}
