using Ironwood.Application.Common.Interfaces;
using Ironwood.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;

namespace Ironwood.Infrastructure.Persistence
{
    public class IronwoodDbContext : DbContext,   IIronwoodDbContext
    {
        public DbSet<User> Users { get ; set; }
		public DbSet<UserLogin> UserLogins { get; set; }
		public DbSet<Wallet> Wallets { get; set; }
		public DbSet<WalletTransaction> WalletTransactions { get; set; }
		public DbSet<LoginHistory> LoginHistories { get; set; }
		public DbSet<Voucher> Vouchers { get; set; }
		public DbSet<VoucherTransaction> VoucherTransactions { get; set; }
        public DbSet<Bet> Bets { get ; set; }
        public DbSet<Match> Matches { get; set ; }
        public DbSet<MatchTeamDetail> MatchTeamDetails { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tournament> Tournaments { get; set ; }
        public DbSet<Category> Categories { get; set; }

        public IronwoodDbContext(DbContextOptions<IronwoodDbContext> dbContext) : base (dbContext)
		{ 		
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
