using AccountingManagementSystem.Domain.Entities;
using AccountingManagementSystem.Domain.Interfaces;
using AccountingManagementSystem.Infustracture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Infustracture.Repository
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext context, IUnitofWork unitofWork) : base(context, unitofWork)
        {
        }


        // Implement additional methods specific to Account if needed

        public async Task<bool> HasRelatedTransactionsAsync(int accountId)
        {
            return await _context.TransactionAccounts.AnyAsync(ta => ta.AccountId == accountId);
        }
    }
}
