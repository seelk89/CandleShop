using CandleShop.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace CandleShop.Infrastructure.Data
{
    public class CandleShopContext : DbContext
    {
        public CandleShopContext(DbContextOptions <CandleShopContext> opt) : base(opt)
        {
            
        }
        
        public DbSet<Candle> Candles { get; set; }
    }
}