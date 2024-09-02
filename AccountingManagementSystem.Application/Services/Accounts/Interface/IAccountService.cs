using AccountingManagementSystem.Application.Common.Handler;
using AccountingManagementSystem.Application.ViewModels;

namespace AccountingManagementSystem.Application.Services.Accounts.Interface
{
    public interface IAccountService
    {
        Task<Result<AccountViewModel>> CreateAsync(AccountViewModel account);
        Task<Result<IEnumerable<AccountViewModel>>> GetAllAsync();
        Task<Result<bool>> DeleteAsync(int accountId);
    }
}
