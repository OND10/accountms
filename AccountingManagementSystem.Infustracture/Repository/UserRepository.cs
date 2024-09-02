using AccountingManagementSystem.Domain.Common.Exceptions;
using AccountingManagementSystem.Domain.Entities;
using AccountingManagementSystem.Domain.Interfaces;
using AccountingManagementSystem.Infustracture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Infustracture.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context, IUnitofWork unitofWork) : base(context, unitofWork)
        {
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            // Include roles when fetching a user
            return await _context.Users
                .Include(u => u.Role) // Assuming a User has a single Role
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            var user = await GetByUsernameAsync(username);
            if (user == null)
                return false;

            // Validate the hashed password
            return VerifyPasswordHash(password, user.PasswordHash);
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            using var hmac = new HMACSHA512();
            var computedHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            return computedHash == storedHash;
        }
    }
}
