﻿using AccountingManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Domain.Interfaces
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<bool> HasRelatedTransactionsAsync(int accountId);
    }
}