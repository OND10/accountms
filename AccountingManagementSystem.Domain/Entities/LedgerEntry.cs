using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Domain.Entities
{
    public class LedgerEntry
    {
        public int LedgerEntryId { get; set; }
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
        public int? JournalEntryId { get; set; }
        public DateTime Date {  get; set; }
    }
}
