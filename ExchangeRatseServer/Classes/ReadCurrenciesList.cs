using Newtonsoft.Json;

namespace ExchangeRatseServer.Classes
{
    //This class accesses the API and retrieves a list of currencies
    public class ReadCurrenciesList
    {

        private readonly HttpClient client = new HttpClient();
        private readonly string apiUrl = "https://api.freecurrencyapi.com/v1/currencies?apikey=fca_live_0g5M7I5Ub3fXN57pLTC3ZOcVsEaHPviHfLSpB4Za&currencies=AUD%2CBGN%2CBRL%2CCAD%2CCHF%2CCNY%2CCZK%2CDKK%2CEUR%2CGBP%2CHKD%2CHRK%2CHUF%2CIDR%2CILS%2CINR%2CISK%2CJPY%2CKRW%2CMXN%2CMYR%2CNOK%2CNZD%2CPHP%2CPLN%2CRON%2CRUB%2CSEK&base_currency=SEK";

        public async Task<List<String>> ReadAsync()
        {
            List<String> currencies = new List<String>();
            HttpResponseMessage response = await client.GetAsync(apiUrl);// Asynchronously retrieves a list of currencies

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                CurrencyData currenciesData = JsonConvert.DeserializeObject<CurrencyData>(responseContent);

                foreach (var currencyEntry in currenciesData.Data)
                {
                    Currency currency = currencyEntry.Value;
                    string name = currencyEntry.Key; // This will be the currency code like "EUR", "USD", etc.
                    currencies.Add(name);
                }
            }

            return currencies;
        }
    }
}
