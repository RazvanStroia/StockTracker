using Microsoft.Extensions.Configuration;
using StockTracker;
using StockTracker.Model;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace StockTracker.Services
{
    public class StockService
    {
        IConfiguration configuration;
        HttpClient httpClient;
        private string stockApiKey;
        private string stockApiLimit;
        public StockService(IConfiguration config)
        {
            configuration = config;
            this.httpClient = new HttpClient();
            stockApiKey = configuration.GetValue<string>("STOCKTRAKCER_API_KEY");
            stockApiLimit = configuration.GetValue<string>("STOCKTRACKER_API_LIMIT");
        }

        List<Stock> stockList;
        
        public async Task<List<Stock>> GetTickers()
        {
            if (stockList?.Count > 0)
                return stockList;
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.marketstack.com/v2/tickerslist?exchange=XNAS&limit=" + stockApiLimit + "&access_key=" + stockApiKey),
                Headers =
                {
                    {"Accept", "application/json" },
                },
            };
            using (var response = await httpClient.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    JsonObject resp;
                    resp = await response.Content.ReadFromJsonAsync<JsonObject>();
                    KeyValuePair<string, JsonNode> result = resp.GetAt(1);
                    JsonNode data = result.Value;
                    stockList = JsonSerializer.Deserialize<List<Stock>>(data);
                }
            }
            return stockList;
        }
        StockExchangeEOD exchangeDetails;
        public async Task<StockExchangeEOD> GetExchangeDetails(string tickerParam)
        {
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.marketstack.com/v2/exchanges/XNAS/eod/latest?symbols="+ tickerParam +"&limit="+ stockApiLimit +"&access_key=" + stockApiKey),
                Headers =
                {
                    {"Accept", "application/json" },
                },
            };
            using (var response = await httpClient.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    JsonObject resp;
                    resp = await response.Content.ReadFromJsonAsync<JsonObject>();
                    KeyValuePair<string, JsonNode> result = resp.GetAt(1);
                    JsonNode data = result.Value;
                    exchangeDetails = JsonSerializer.Deserialize<StockExchangeEOD>(data);
                }
            }
            return exchangeDetails;
        }
        StockEOD stockDetails;

        public async Task<StockEOD> GetStockDetails(Stock stock)
        {
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.marketstack.com/v2/tickers/"+ stock.ticker + "/eod/latest?limit=" + stockApiLimit + "&access_key=" + stockApiKey),
                Headers =
    {
        { "Accept", "application/json" },
    },
            };
            using (var response = await httpClient.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    stockDetails = JsonSerializer.Deserialize<StockEOD>(json);
                }
            }
            return stockDetails;
        }
    }
}
