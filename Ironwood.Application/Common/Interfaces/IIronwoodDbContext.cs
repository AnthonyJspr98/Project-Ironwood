using Ironwood.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Ironwood.Application.Common.Interfaces
{
    public interface IIronwoodDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletTransaction> WalletTransactions { get; set; }
        public DbSet<LoginHistory> LoginHistories { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherTransaction> VoucherTransactions { get; set; }
    }
}
