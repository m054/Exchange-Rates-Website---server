using Newtonsoft.Json;

namespace ExchangeRatseServer.Classes
{
    //This class accesses the API and retrieves exchange rates for a given currency
    public class ReadExchangeRates
    {

        private readonly HttpClient client = new HttpClient();
        private readonly string apiUrl = "https://api.freecurrencyapi.com/v1/latest?apikey=fca_live_0g5M7I5Ub3fXN57pLTC3ZOcVsEaHPviHfLSpB4Za&currencies=AUD%2CBGN%2CBRL%2CCAD%2CCHF%2CCNY%2CCZK%2CDKK%2CEUR%2CGBP%2CHKD%2CHRK%2CHUF%2CIDR%2CILS%2CINR%2CISK%2CJPY%2CKRW%2CMXN%2CMYR%2CNOK%2CNZD%2CPHP%2CPLN%2CRON%2CRUB%2CSEK&base_currency=";

        public async Task<List<Rates>> Read(string baseCurrency)
        {

            List<Rates> rats = new List<Rates>();
            HttpResponseMessage response = await client.GetAsync(apiUrl + baseCurrency);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                ExchangeRatesData exchangeRatesl = JsonConvert.DeserializeObject<ExchangeRatesData>(responseContent);


                foreach (var exchangeRatesEntry in exchangeRatesl.Data)
                {
                    Rates rate = new Rates();
                    rate.CurrencyName = exchangeRatesEntry.Key;
                    rate.Rate = exchangeRatesEntry.Value;
                    rats.Add(rate);
                }

            }
            return rats;
        }
    }
}
