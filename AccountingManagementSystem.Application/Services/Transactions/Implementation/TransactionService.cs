using AccountingManagementSystem.Application.Common.Handler;
using AccountingManagementSystem.Application.Services.Transactions.Interface;
using AccountingManagementSystem.Application.ViewModels;
using AccountingManagementSystem.Domain.Entities;
using AccountingManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Application.Services.Transactions.Implementation
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;

        public TransactionService(ITransactionRepository transactionRepository, IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }
        public async Task<Result<TransactionViewModel>> CreateAsync(TransactionViewModel transaction)
        {
            var model = new Transaction
            {
                TransactionAccounts = transaction.TransactionAccounts.ToList(),
                ReferenceNumber = transaction.ReferenceNumber,
                TransactionId = transaction.TransactionId,
                TransactionType = transaction.TransactionType,
            };

            if (!await _transactionRepository.ValidateTransactionAsync(model))
            {
                throw new InvalidOperationException("Total debits and credits must match.");
            }

            // Update account balances based on transaction
            foreach (var ta in transaction.TransactionAccounts)
            {
                var account = await _accountRepository.GetByIdAsync(ta.AccountId);
                if (ta.IsDebit)
                {
                    account.OpeningBalance -= ta.Amount;
                }
                else
                {
                    account.OpeningBalance += ta.Amount;
                }
            }

            await _transactionRepository.AddAsync(model);


            return await Result<TransactionViewModel>.SuccessAsync(transaction, "Added Successfully", true);
        }

        public async Task<Result<IEnumerable<TransactionViewModel>>> GetAllAsync()
        {
            var result = await _transactionRepository.GetAllAsync();
            var viewmodelList = new List<TransactionViewModel>();

            foreach (var item in result)
            {
                var transaction = new TransactionViewModel
                {
                    TransactionAccounts = item.TransactionAccounts,
                    ReferenceNumber = item.ReferenceNumber,
                    TransactionType = item.TransactionType,
                    TransactionId = item.TransactionId,

                };
                viewmodelList.Add(transaction);
            }

            return await Result<IEnumerable<TransactionViewModel>>.SuccessAsync(viewmodelList, "Get all Transactions Successfully", true);

        }
    }
}
