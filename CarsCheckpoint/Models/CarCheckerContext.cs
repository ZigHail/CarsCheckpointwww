using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarsCheckpoint.Models
{
    public class CarCheckerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<RFIDCard> Cards { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<WriteOff> WriteOff { get; set; }
        public DbSet<Entrance> Entrances { get; set; }
        public DbSet<AdminSettings> AdminSettings { get; set; }

    }
}