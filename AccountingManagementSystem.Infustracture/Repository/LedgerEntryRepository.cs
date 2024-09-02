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
    public class LedgerEntryRepository : GenericRepository<LedgerEntry>, ILedgerEntryRepository
    {
        public LedgerEntryRepository(AppDbContext context, IUnitofWork unitofWork) :base(context, unitofWork)
        { 
        }

        public async Task<IEnumerable<LedgerEntry>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var result = await _context.LedgerEntries
            .Where(le => le.Date >= startDate && le.Date <= endDate)
            .ToListAsync();
            
            if(result.Count > 0)
            {
                return result;
            }

            return Enumerable.Empty<LedgerEntry>();
        }
    }
}
