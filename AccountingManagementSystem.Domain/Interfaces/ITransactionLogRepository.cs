using AccountingManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Domain.Interfaces
{
    public interface ITransactionLogRepository : IGenericRepository<TransactionLog>
    {
        // Additional method to filter logs by type
        Task<IEnumerable<TransactionLog>> GetLogsByTypeAsync(string logType);
    }
}
