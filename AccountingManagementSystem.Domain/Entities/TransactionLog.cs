using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Domain.Entities
{
    public class TransactionLog
    {
        public int TransactionLogId { get; set; }
        public string LogType { get; set; } // Type of log, e.g., create, update, delete
        public string OldValue { get; set; } // Previous value of the modified field
        public string NewValue { get; set; } // New value of the modified field
        public DateTime Timestamp { get; set; }
    }
}
