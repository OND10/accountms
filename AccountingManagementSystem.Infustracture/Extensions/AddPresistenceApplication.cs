using AccountingManagementSystem.Domain.Entities;
using AccountingManagementSystem.Domain.Interfaces;
using AccountingManagementSystem.Infustracture.Data;
using AccountingManagementSystem.Infustracture.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AccountingManagementSystem.Infustracture.Extensions
{
    public static class AddPresistenceExtensision
    {
        public static IServiceCollection AddPresistence(this IServiceCollection service, IConfiguration configuration)
        {

            service.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            service.AddScoped<IAccountRepository, AccountRepository>();
            service.AddScoped<ITransactionRepository, TransactionRepository>();
            service.AddScoped<ITransactionAccountRepository, TransactionAccountRepository>();
            service.AddScoped<ILedgerEntryRepository, LedgerEntryRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IUserRoleRepository, UserRoleRepository>();
            service.AddScoped<ITransactionLogRepository, TransactionLogRepository>();

            // Register the unit of work if it's used in your project
            service.AddScoped<IUnitofWork, UnitofWork>();


            return service;
        }
    }
}
