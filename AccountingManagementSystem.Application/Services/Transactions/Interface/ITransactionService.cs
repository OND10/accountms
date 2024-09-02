using AccountingManagementSystem.Application.Common.Handler;
using AccountingManagementSystem.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Application.Services.Transactions.Interface
{
    public interface ITransactionService
    {
        Task<Result<TransactionViewModel>> CreateAsync(TransactionViewModel transaction);
        Task<Result<IEnumerable<TransactionViewModel>>> GetAllAsync();

    }
}
