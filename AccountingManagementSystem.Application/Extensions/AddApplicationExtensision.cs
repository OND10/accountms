using AccountingManagementSystem.Application.Services.Accounts.Implementation;
using AccountingManagementSystem.Application.Services.Accounts.Interface;
using AccountingManagementSystem.Application.Services.AccountTransactions.Implementation;
using AccountingManagementSystem.Application.Services.AccountTransactions.Interface;
using AccountingManagementSystem.Application.Services.Transactions.Implementation;
using AccountingManagementSystem.Application.Services.Transactions.Interface;
using AccountingManagementSystem.Application.Services.Users.Implementation;
using AccountingManagementSystem.Application.Services.Users.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace AccountingManagementSystem.Application.Extensions
{
    public static class AddApplicationExtensision
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAccountTransactionService, AccountTransactionService>();

            return services;
        }
    }
}
