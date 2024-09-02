using AccountingManagementSystem.Application.Common.Handler;
using AccountingManagementSystem.Application.Services.Users.Interface;
using AccountingManagementSystem.Application.ViewModels;
using AccountingManagementSystem.Domain.Entities;
using AccountingManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Application.Services.Users.Implementation
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;

        public UserService(IUserRepository userRepository, IUserRoleRepository userRoleRepository)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null)
            {
                return (false, "User not found.");
            }

            // Verify password
            //if (!VerifyPasswordHash(password, user.PasswordHash))
            //{
            //    return (false, "Invalid password.");
            //}

            return (true, string.Empty);
        }

        public async Task CreateUserAsync(UserViewModel userViewModel, string password)
        {
            // Find the role based on RoleId
            var role = await _userRoleRepository.GetByIdAsync(userViewModel.RoleId);
            if (role == null)
            {
                throw new Exception("Invalid role specified.");
            }

            // Hash the password before storing it
            var user = new User
            {
                Username = userViewModel.Username,
                Email = userViewModel.Email,
                PasswordHash = HashPassword(password),
                RoleId = role.UserRoleId // Set RoleId based on the selected role
            };

            await _userRepository.AddAsync(user);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.GetByUsernameAsync(username);
        }

        private string HashPassword(string password)
        {
            using var hmac = new HMACSHA512();
            return Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            using var hmac = new HMACSHA512();
            var computedHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            return computedHash == storedHash;
        }
    }
}
