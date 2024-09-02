using AccountingManagementSystem.Domain.Common.Exceptions;
using AccountingManagementSystem.Domain.Entities;
using AccountingManagementSystem.Domain.Interfaces;
using AccountingManagementSystem.Infustracture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Infustracture.Repository
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(AppDbContext context, IUnitofWork unitofWork):base(context, unitofWork)
        {
            
        }

        public async Task<UserRole> GetByRoleNameAsync(string roleName)
        {
            // Fetch a role by its name
            return await _context.UserRoles
                .FirstOrDefaultAsync(r => r.RoleName == roleName);
        }

    }
}
