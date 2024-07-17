using ExchangeRatseServer.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRatseServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRatse : ControllerBase
    {
        ReadCurrenciesList currenciesList=new ReadCurrenciesList();
        ReadExchangeRates exchangeList = new ReadExchangeRates();



        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            return Ok( await currenciesList.ReadAsync());
        }


        [HttpGet("GetExchangeRatse/{baseCurrency}")]
        public async Task<ActionResult> GetExchangeRatse(string baseCurrency)
        {
            return Ok(await exchangeList.Read(baseCurrency));
        }
    }
}
