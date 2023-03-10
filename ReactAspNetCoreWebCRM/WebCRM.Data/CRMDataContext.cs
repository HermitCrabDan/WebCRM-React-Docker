using Microsoft.EntityFrameworkCore;
using WebCRM.Data.Entities;

namespace WebCRM.Data
{
    /// <summary>
    /// The CRM data context
    /// </summary>
    public class CRMDataContext: DbContext, ICRMDataContext
    {
        public CRMDataContext(DbContextOptions<CRMDataContext> options) 
            : base(options) 
        {
        }

        /// <summary>
        /// The application roles table
        /// </summary>
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        /// <summary>
        /// The contracts table
        /// </summary>
        public DbSet<Contract> Contracts { get; set; }

        /// <summary>
        /// The contract customers table
        /// </summary>
        public DbSet<ContractCustomer> ContractCustomers { get; set; }

        /// <summary>
        /// The contract monthly payments entities
        /// </summary>
        public DbSet<ContractMonthlyPayment> ContractMonthlyPayments { get; set; }

        /// <summary>
        /// The contract notes table
        /// </summary>
        public DbSet<ContractNote> ContractNotes { get; set; }

        /// <summary>
        /// The contract payments table
        /// </summary>
        public DbSet<ContractPayment> ContractPayments { get; set; }

        /// <summary>
        /// The role members table
        /// </summary>
        public DbSet<RoleMember> RoleMembers { get; set; }

        /// <summary>
        /// The users table
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// The entity application role associations
        /// </summary>
        public DbSet<EntityApplicationRole> EntityApplicationRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleMember>()
                .HasOne(m => m.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(m => m.UserId)
                .HasPrincipalKey(u => u.Id);

            modelBuilder.Entity<RoleMember>()
                .HasOne(m => m.Role)
                .WithMany(r => r.RoleMembers)
                .HasForeignKey(m => m.RoleId)
                .HasPrincipalKey(r => r.Id);

            modelBuilder.Entity<ContractPayment>()
                .HasOne(p => p.EnteredByUser)
                .WithMany(c => c.ContractPaymentsEnteredByUser)
                .HasForeignKey(p => p.EnteredByUserId)
                .HasPrincipalKey(c => c.Id);

            modelBuilder.Entity<ContractPayment>()
                .HasOne(p => p.Contract)
                .WithMany(c => c.ContractPayments)
                .HasForeignKey(p => p.ContractId)
                .HasPrincipalKey(c => c.Id);

            modelBuilder.Entity<ContractPayment>()
                .HasOne(p => p.ContractMonthlyPayment)
                .WithMany(mp => mp.ContractPayments)
                .HasForeignKey(p => p.ContractMonthlyPaymentId)
                .HasPrincipalKey(mp => mp.Id);

            modelBuilder.Entity<ContractCustomer>()
                .HasOne(c => c.Customer)
                .WithMany(u => u.ContractCustomers)
                .HasForeignKey(c => c.CustomerId)
                .HasPrincipalKey(u => u.Id);

            modelBuilder.Entity<ContractCustomer>()
                .HasOne(cc => cc.Contract)
                .WithMany(c => c.ContractCustomers)
                .HasForeignKey(cc => cc.ContractId)
                .HasPrincipalKey(c => c.Id);

            modelBuilder.Entity<ContractNote>()
                .HasOne(n => n.Contract)
                .WithMany(c => c.ContractNotes)
                .HasForeignKey(n => n.ContractId)
                .HasPrincipalKey(c => c.Id);

            modelBuilder.Entity<ContractNote>()
                .HasOne(n => n.User)
                .WithMany(u => u.ContractNotesCreatedByUser)
                .HasForeignKey(n => n.UserId)
                .HasPrincipalKey(u => u.Id);

            modelBuilder.Entity<ContractMonthlyPayment>()
                .HasOne(mp => mp.Contract)
                .WithMany(c => c.ContractMonthlyPayments)
                .HasForeignKey(mp => mp.ContractId)
                .HasPrincipalKey(c => c.Id);

            modelBuilder.Entity<ContractMonthlyPayment>()
                .HasOne(mp => mp.PaymentSkippedByUser)
                .WithMany(u => u.ContractMonthlyPaymentsSkippedByUser)
                .HasForeignKey(mp => mp.PaymentSkippedByUserId)
                .HasPrincipalKey (u => u.Id);

            modelBuilder.Entity<EntityApplicationRole>()
                .HasOne(e => e.ApplicationRole)
                .WithMany(a => a.EntityApplicationRoles)
                .HasForeignKey(e => e.ApplicationRoleId)
                .HasPrincipalKey(a => a.Id);
        }
    }
}
