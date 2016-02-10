using System.Data.Entity;

namespace MSPAccounting.Models
{
    class MSPAccountingContext : DbContext
    {
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<Earning> Earning { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<State> State { get; set; }
    }
}
