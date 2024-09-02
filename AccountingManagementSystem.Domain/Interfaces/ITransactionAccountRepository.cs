using AccountingManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Domain.Interfaces
{
    public interface ITransactionAccountRepository : IGenericRepository<TransactionAccount>
    {
        // No additional methods required at this time
    }
}
