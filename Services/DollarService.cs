using Newtonsoft.Json.Linq;

namespace ExpensesTracker.Services
{
    public class DollarValues
    {
        public decimal PriceBuy { get; set; }
        public decimal PriceSell { get; set; }
        public string Date { get; set; }

        public async Task GetLastDollarValues()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = "https://criptoya.com/api/binance/usdt/ars/1";
                    client.DefaultRequestHeaders.Clear();

                    var response = client.GetAsync(url).Result;
                    var res = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(res);

                    if (json.HasValues)
                    {
                        PriceBuy = (decimal)json.Root["totalBid"];
                        decimal.Round(PriceBuy, 1);

                        PriceSell = (decimal)json.Root["totalAsk"];
                        decimal.Round(PriceSell, 1);

                        Date = DateTime.Now.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                PriceBuy = 0;
                PriceSell = 0;
                Date = "";

                var exeption = ex.Message;
            }
        }
    }
}