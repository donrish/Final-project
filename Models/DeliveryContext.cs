using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DelsProject.Models
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext() : base()
        {

        }

        public DeliveryContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Executive> Executives { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
