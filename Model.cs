using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AgilityFramework
{
    
        public class StockContext : DbContext
        {
            public DbSet<Stocks> Stock { get; set; }
        
            protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite("Data Source" = + Path.Combine(ApplicationData.Current.LocalFolder.Path, "stocks.db"));
        }

        public class Stocks
        {
        public int ID { get; set; }
        public DateTime StockRecord { get; set; }
        public string Symbol { get; set; }
        public string Price { get; set; }
        public string Change { get; set; }
        public string PercentChange { get; set; }
        }
    
}
