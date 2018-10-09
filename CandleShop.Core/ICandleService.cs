using System.Collections.Generic;
using CandleShop.Core.Entity;

namespace CandleShop.Core
{
    public interface ICandleService
    {
        List<Candle> GetCandles(PagingFilter filter);

        Candle CandleFoundById(int id);

        void CreateCandle(Candle candle);

        void UpdateCandle(int id, Candle newCandleData);

        void DeleteCandle(int id);
    }
}