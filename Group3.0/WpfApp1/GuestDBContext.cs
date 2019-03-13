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
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Stay> Stays { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Strike> Strikes { get; set; }
        public DbSet<EmergencyContact> EmergencyContact { get; set; }

    }
}
