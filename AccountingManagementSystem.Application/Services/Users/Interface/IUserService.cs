using AccountingManagementSystem.Application.Common.Handler;
using AccountingManagementSystem.Application.ViewModels;
using AccountingManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Application.Services.Users.Interface
{
    public interface IUserService
    {
        Task<(bool IsSuccess, string ErrorMessage)> AuthenticateAsync(string username, string password);
        Task CreateUserAsync(UserViewModel userViewModel, string password);
        Task<User> GetUserByUsernameAsync(string username);

    }
}
