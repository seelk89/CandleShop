using CandleShop.Core.Entity;

namespace CandleShop.Infrastructure.Data
{
    public class DbInitializer
    {
        public static void SeedDb(CandleShopContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            
            var candle1 = ctx.Candles.Add(new Candle()
            {
                name = "Candle1",
                type = "Wax",
                price = 10.0,
                stock = 3,
                imageURL = "Find something"
            }).Entity;
            
            var candle2 = ctx.Candles.Add(new Candle()
            {
                name = "Candle2",
                type = "Paraffin",
                price = 20.0,
                stock = 3,
                imageURL = "Find something"
            }).Entity;
            
            var candle3 = ctx.Candles.Add(new Candle()
            {
                name = "Candle3",
                type = "Some other wax",
                price = 30.0,
                stock = 3,
                imageURL = "Find something"
            }).Entity;
        
            ctx.SaveChanges();
        }
    }
}