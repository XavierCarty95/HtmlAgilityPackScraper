using System;
using Microsoft.EntityFrameworkCore;
namespace AgilityFramework
{
    
        public class StockDataContext : DbContext
        {
            public DbSet<StockData> Stock { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite("Data Source= ./stocks.db");
        }

        public class StockData
        {
            public int ID { get; set; }
            public DateTime StockRecord { get; set; }
            public string Symbol { get; set; }
            public string Price { get; set; }
            public string Change { get; set; }
            public string PercentChange { get; set; }
        }
    
}
