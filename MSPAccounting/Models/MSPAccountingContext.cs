using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
