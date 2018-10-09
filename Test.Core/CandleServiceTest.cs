using System;
using System.IO;
using CandleShop.Core;
using CandleShop.Core.DomainServices;
using CandleShop.Core.Entity;
using Xunit;
using Moq;

namespace Test.Core
{
    public class CandleServiceTest
    {
        //Could just copy this for all other values of candle
        [Fact]
        public void CreateCandleNameMissingThrowsException()
        {
            var candleRepo = new Mock<ICandleRepository>();
            
            //Magic
            candleRepo.Setup(cr => cr.CandleFoundById(It.IsAny<int>())).Returns(new Candle(){id = 1});
            
            ICandleService service =  new CandleService(candleRepo.Object);
            
            var candle = new Candle()
            {
                price = 10.0,
                stock = 3,
                type = "Wax",
                imageURL = "Something"
            };
            
            Exception ex = Assert.Throws<InvalidDataException>(() => service.CreateCandle(candle));
            
            Assert.Equal("Candle needs a name", ex.Message);  
        }
        
        [Fact]
        public void CreateCandleShouldCallCandleRepositoryCreateCandleOnce()
        {
            var candleRepo = new Mock<ICandleRepository>();
            
            //Magic
            candleRepo.Setup(cr => cr.CandleFoundById(It.IsAny<int>())).Returns(new Candle(){id = 1});
            
            ICandleService service =  new CandleService(candleRepo.Object);
            
            var candle = new Candle()
            {
                name = "Candle",
                price = 10.0,
                stock = 3,
                type = "Wax",
                imageURL = "Something"
            };
            
            service.CreateCandle(candle);
            candleRepo.Verify(cr => cr.CreateCandle(It.IsAny<Candle>()), Times.Once);
        }
        
        [Fact]
        public void DeleteCandleShouldBeCalledOnce()
        {
            var candleRepo = new Mock<ICandleRepository>();
            
            candleRepo.Setup(cr => cr.DeleteCandle(1));
            
            ICandleService service = new CandleService(candleRepo.Object);
            
            service.DeleteCandle(1);
            candleRepo.Verify(cr => cr.DeleteCandle(1), Times.Once);
        }
    }
}