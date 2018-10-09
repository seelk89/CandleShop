using System.Collections.Generic;
using System.IO;
using System.Linq;
using CandleShop.Core.DomainServices;
using CandleShop.Core.Entity;

namespace CandleShop.Core
{
    public class CandleService : ICandleService
    {
        private readonly ICandleRepository _candleRepository;

        public CandleService(ICandleRepository candleRepository)
        {
            _candleRepository = candleRepository;
        }
        
        public List<Candle> GetCandles(PagingFilter filter)
        {
            return _candleRepository.ReadCandles(filter).ToList();
        }

        public Candle CandleFoundById(int id)
        {
            return _candleRepository.CandleFoundById(id);
        }

        public void CreateCandle(Candle candle)
        {
            if (string.IsNullOrEmpty(candle.name))
                throw new InvalidDataException("Candle needs a name");
            _candleRepository.CreateCandle(candle);
        }

        public void UpdateCandle(int id, Candle newCandleData)
        {
            _candleRepository.UpdateCandle(id, newCandleData);
        }

        public void DeleteCandle(int id)
        {
            _candleRepository.DeleteCandle(id);
        }
    }
}