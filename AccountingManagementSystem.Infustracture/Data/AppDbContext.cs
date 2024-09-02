using AccountingManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingManagementSystem.Infustracture.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Account>? Accounts { get; set; }
        public DbSet<Transaction>? Transactions { get; set; }
        public DbSet<TransactionAccount>? TransactionAccounts { get; set; }
        public DbSet<LedgerEntry>? LedgerEntries { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<UserRole>? UserRoles { get; set; }
        public DbSet<TransactionLog>? TransactionLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Accounts and Transactions - Many-to-Many via TransactionAccounts
            modelBuilder.Entity<TransactionAccount>()
                .HasKey(ta => new { ta.TransactionId, ta.AccountId }); // Composite Key

            modelBuilder.Entity<TransactionAccount>()
                .HasOne(ta => ta.Transaction)
                .WithMany(t => t.TransactionAccounts)
                .HasForeignKey(ta => ta.TransactionId);

            modelBuilder.Entity<TransactionAccount>()
                .HasOne(ta => ta.Account)
                .WithMany(a => a.TransactionAccounts)
                .HasForeignKey(ta => ta.AccountId);

            // Transactions and LedgerEntries - One-to-Many
            //modelBuilder.Entity<Transaction>()
            //    .HasMany(t => t.LedgerEntries)
            //    .WithOne(le => le.Transaction)
            //    .HasForeignKey(le => le.TransactionId);

            // Users and UserRoles - Many-to-Many
            modelBuilder.Entity<User>()
             .HasOne(u => u.Role)
             .WithMany(r => r.Users)
             .HasForeignKey(u => u.RoleId)
             .OnDelete(DeleteBehavior.Restrict); // Table for Many-to-Many

            base.OnModelCreating(modelBuilder);
        }


    }
}
