using Microsoft.EntityFrameworkCore;
using StockV1.Models;

namespace StockV1.Context
{
    public class StockContext
        : DbContext
    {
        public StockContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Broker> Brokers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
    }
}
