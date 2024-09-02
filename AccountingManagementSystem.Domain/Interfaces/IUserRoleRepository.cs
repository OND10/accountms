using AccountingManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Domain.Interfaces
{
    public interface IUserRoleRepository : IGenericRepository<UserRole>
    {
        // Additional method to find roles by name
        Task<UserRole> GetByRoleNameAsync(string roleName);
    }
}
