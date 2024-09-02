using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Domain.Entities
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public string RoleName { get; set; } // e.g., "Admin", "User", "Manager"
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
