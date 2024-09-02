using AccountingManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Domain.Interfaces
{
    public interface ILedgerEntryRepository : IGenericRepository<LedgerEntry>
    {
        // Additional method to filter ledger entries by date range
        Task<IEnumerable<LedgerEntry>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
