using AgileTesting.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileTesting
{
    class GuestDBContext : DbContext
    {
        public DbSet<Guest> guests { get; set; }
        public DbSet<Calendar> calendars { get; set; }
        public DbSet<Stay> stays { get; set; }
        public DbSet<Rule> rules { get; set; }
        public DbSet<Strike> strikes { get; set; }
        public DbSet<EmergencyContact> emergencyContact { get; set; }

    }
}
