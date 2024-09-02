using AccountingManagementSystem.Application.Common.Handler;
using AccountingManagementSystem.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Application.Services.AccountTransactions.Interface
{
    public interface IAccountTransactionService
    {
        Task<Result<AccountTransactionViewModel>> CreateAsync(AccountTransactionViewModel model);
        Task<Result<IEnumerable<AccountTransactionViewModel>>> GetAllAsync();
    }
}
