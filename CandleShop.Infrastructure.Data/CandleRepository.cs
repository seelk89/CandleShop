using System.Collections.Generic;
using System.Linq;
using CandleShop.Core.DomainServices;
using CandleShop.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace CandleShop.Infrastructure.Data
{
    public class CandleRepository : ICandleRepository
    {
        readonly CandleShopContext _ctx;

        public CandleRepository(CandleShopContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Candle> ReadCandles(PagingFilter filter)
        {
            if (filter == null)
            {
                return _ctx.Candles;
            }

            return _ctx.Candles.Skip((filter.CurrentPage - 1) * filter.ItemsPrPage).Take(filter.ItemsPrPage);
        }

        public Candle CandleFoundById(int id)
        {
            return _ctx.Candles.FirstOrDefault(candle => candle.id == id);
        }

        public void CreateCandle(Candle candle)
        {
            _ctx.Add(candle);
            _ctx.SaveChanges();
        }

        public void UpdateCandle(int id, Candle newCandleData)
        {
            _ctx.Attach(newCandleData).State = EntityState.Modified;
            
            _ctx.SaveChanges();
        }

        public void DeleteCandle(int id)
        {
            _ctx.Candles.Remove(CandleFoundById(id));
            _ctx.SaveChanges();
        }
    }
}