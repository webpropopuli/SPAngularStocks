using Microsoft.EntityFrameworkCore;
using StockApp1.API.MyModels;

namespace StockApp1.API.MyData
{
    public class StockDataContext : DbContext
    {
        public StockDataContext(DbContextOptions<StockDataContext> options) : base(options) {}

        public DbSet<Value> Values {get; set;}
    }
}