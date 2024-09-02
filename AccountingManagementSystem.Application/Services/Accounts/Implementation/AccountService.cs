using AccountingManagementSystem.Application.Common.Handler;
using AccountingManagementSystem.Application.Services.Accounts.Interface;
using AccountingManagementSystem.Application.ViewModels;
using AccountingManagementSystem.Domain.Entities;
using AccountingManagementSystem.Domain.Interfaces;

namespace AccountingManagementSystem.Application.Services.Accounts.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<Result<AccountViewModel>> CreateAsync(AccountViewModel account)
        {

            var model = new Account
            {
                AccountId = account.AccountId,
                AccountNumber = account.AccountNumber,
                AccountType = account.AccountType,
                IsActive = account.IsActive,
                TransactionAccounts = account.TransactionAccounts ?? new List<TransactionAccount>(),
                OpeningBalance = account.OpeningBalance,
            };



            if (string.IsNullOrEmpty(account.AccountNumber) || account.OpeningBalance < 0)
            {
                throw new InvalidOperationException("Invalid account details.");
            }

            await _accountRepository.AddAsync(model);

            return await Result<AccountViewModel>.SuccessAsync(account, "Added Successfully", true);

        }

        public async Task<Result<bool>> DeleteAsync(int accountId)
        {
            var result = await _accountRepository.DeleteAsync(accountId);

            return await Result<bool>.SuccessAsync(result, "Deleted Successfully", true);
        }

        public async Task<Result<IEnumerable<AccountViewModel>>> GetAllAsync()
        {
            var result = await _accountRepository.GetAllAsync();

            var viewmodel = new List<AccountViewModel>();

            foreach (var item in result)
            {
                var acount = new AccountViewModel
                {
                    AccountNumber = item.AccountNumber,
                    AccountType = item.AccountType,
                    IsActive = item.IsActive,
                    TransactionAccounts = item.TransactionAccounts,
                    AccountId = item.AccountId,
                    OpeningBalance = item.OpeningBalance,
                };
                viewmodel.Add(acount);
            }

            return await Result<IEnumerable<AccountViewModel>>.SuccessAsync(viewmodel, "Get all Accounts Successfully", true);
        }
    }
}
