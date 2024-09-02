using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Store hashed passwords
        public string Email { get; set; }
        public DateTime? LastLogin { get; set; }
        public int RoleId { get; set; } // Foreign key for UserRole
        public UserRole Role { get; set; }
    }
}
