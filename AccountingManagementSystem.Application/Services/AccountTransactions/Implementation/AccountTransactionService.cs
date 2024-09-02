using AccountingManagementSystem.Application.Common.Handler;
using AccountingManagementSystem.Application.Services.AccountTransactions.Interface;
using AccountingManagementSystem.Application.ViewModels;
using AccountingManagementSystem.Domain.Entities;
using AccountingManagementSystem.Domain.Interfaces;

namespace AccountingManagementSystem.Application.Services.AccountTransactions.Implementation
{
    public class AccountTransactionService : IAccountTransactionService
    {
        private readonly ITransactionAccountRepository _repository;
        public AccountTransactionService(ITransactionAccountRepository repository)
        {
            _repository = repository;
        }


        public async Task<Result<AccountTransactionViewModel>> CreateAsync(AccountTransactionViewModel entity)
        {
            var model = new TransactionAccount
            {
                TransactionId = entity.TransactionId,
                AccountId = entity.AccountId,
                Account = entity.Account,
                Amount = entity.Amount,
                IsDebit = entity.IsDebit,
                TransactionAccountId = entity.TransactionAccountId,
                Transaction = entity.Transaction,
            };

            var result = await _repository.AddAsync(model);

            return await Result<AccountTransactionViewModel>.SuccessAsync(entity, "Created Successfully", true);
        }

        public async Task<Result<IEnumerable<AccountTransactionViewModel>>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            var viewModelList = new List<AccountTransactionViewModel>();
            foreach (var item in result)
            {
                var accountTransaction = new AccountTransactionViewModel
                {
                    TransactionId = item.TransactionId,
                    AccountId = item.AccountId,
                    Amount = item.Amount,
                    IsDebit = item.IsDebit,
                    TransactionAccountId = item.TransactionAccountId,
                    Transaction = item.Transaction,
                    Account = item.Account,
                };
                viewModelList.Add(accountTransaction);
            }

            return await Result<IEnumerable<AccountTransactionViewModel>>.SuccessAsync(viewModelList, "Get All TransactionAccounts Successfully", true);
        }
    }
}
