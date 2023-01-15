using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace tumibankapp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<BankAccountTbl> BankAccounts { get; set; }
        public DbSet<ExternalBanking> ExternalBankings { get; set; }
        public DbSet<InterestRate> InterestRates { get; set; }  
        public DbSet<OverDraft> OverDrafts { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}