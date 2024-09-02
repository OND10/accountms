using AccountingManagementSystem.Domain.Entities;
using AccountingManagementSystem.Domain.Interfaces;
using AccountingManagementSystem.Infustracture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Infustracture.Repository
{
    public class TransactionAccountRepository : GenericRepository<TransactionAccount>, ITransactionAccountRepository
    {
        public TransactionAccountRepository(AppDbContext context, IUnitofWork unitofWork):base(context, unitofWork)
        {
            
        }

    }
}
