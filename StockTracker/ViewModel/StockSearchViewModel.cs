using Microsoft.Extensions.Configuration;
using StockTracker.Services;
using StockTracker.View;

namespace StockTracker.ViewModel
{
    public partial class StockSearchViewModel : BaseViewModel
    {
        public ObservableCollection<Stock> Stocks { get; } = new();
        StockService stockService;
        IConfiguration configuration;
        private string stockLogoPK;
        public StockSearchViewModel(StockService stockService, IConfiguration config)
        {
            Title = "Stock Search";
            this.stockService = stockService;
            this.configuration = config;
            stockLogoPK = configuration.GetValue<string>("STOCKICONS_PK");
        }
        [RelayCommand]
        async Task GetStockBySearchAsync(string query)
        {
            if (IsBusy)
                return;

            try
            {

                IsBusy = true;
                var stocks = await stockService.GetTickersBySearch(query);
                string tickerParam = "";

                if (Stocks.Count != 0)
                    Stocks.Clear();

                foreach (var stock in stocks)
                {
                    if (tickerParam.CompareTo("") == 0)
                    {
                        tickerParam = tickerParam + stock.ticker;
                    }
                    else tickerParam = tickerParam + "," + stock.ticker;
                }
                var exchangeEOD = await stockService.GetExchangeDetails(tickerParam);
                foreach (var stock in stocks)
                {
                    stock.open = exchangeEOD.eod.Find(e => e.symbol.CompareTo(stock.ticker) == 0).open;
                    stock.image = "https://img.logo.dev/ticker/" + stock.ticker + "?token=" + stockLogoPK;
                    Stocks.Add(stock);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get stocks: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }

        }
        [RelayCommand]
        async Task GoToDetails(Stock stock)
        {
            if (stock is null)
                return;

            await Shell.Current.GoToAsync(nameof(StockDetailsPage), true, new Dictionary<string, object>
            {
                {"Stock", stock}
            });
        }
        [RelayCommand]
        async Task TextChanged(string newText)
        {
            if (string.IsNullOrEmpty(newText))
            {
                Stocks.Clear();
            }
            return;
        }
    }
}
