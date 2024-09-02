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
    public class TransactionLogRepository : GenericRepository<TransactionLog>, ITransactionLogRepository
    {
        public TransactionLogRepository(AppDbContext context, IUnitofWork unitofWork): base(context, unitofWork)
        {
            
        }

        public async Task<IEnumerable<TransactionLog>> GetLogsByTypeAsync(string logType)
        {
            var result = await _context.TransactionLogs
                .Where(log => log.LogType == logType)
                .ToListAsync();

            if(result.Count > 0)
            {
                return result;
            }

            return Enumerable.Empty<TransactionLog>();
        }
    }
}
