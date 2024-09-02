using AccountingManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        // Additional method to find a user by email
        Task<User> GetByUsernameAsync(string username);
        Task<bool> ValidateCredentialsAsync(string username, string password);
    }
}
