using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandleShop.Core;
using CandleShop.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CandleShop.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandlesController : ControllerBase
    {
        readonly ICandleService _candleService;

        public CandlesController(ICandleService petShopService)
        {
            _candleService = petShopService;
        }
        
        // GET api/values
        [HttpGet]
        public ActionResult<List<Candle>> Get([FromQuery] PagingFilter filter)
        {
            if (filter.CurrentPage == 0 && filter.ItemsPrPage == 0)
            {
                return _candleService.GetCandles(null);
            }
            
            return _candleService.GetCandles(filter);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}