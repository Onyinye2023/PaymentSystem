using Microsoft.EntityFrameworkCore;
using paymentSystemAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentSystemAPI.Dal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
