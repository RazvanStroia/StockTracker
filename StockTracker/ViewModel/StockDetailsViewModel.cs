using StockTracker.Services;

namespace StockTracker.ViewModel
{
    [QueryProperty(nameof(Stock), "Stock")]
    public partial class StockDetailsViewModel : BaseViewModel
    {
        public StockDetailsViewModel() { }
        [ObservableProperty]
        public partial Stock Stock { get; set; }
        [ObservableProperty]
        public partial StockEOD StockEOD { get; set; }
        StockService stockService;
        public StockDetailsViewModel(StockService stockService)
        {
            this.stockService = stockService;
        }
        [RelayCommand]
        async Task GetStockDetailsAsync()
        {
            if (IsBusy)
                return;

            try
            {

                IsBusy = true;
                var details = await stockService.GetStockDetails(Stock);

                if (StockEOD != null)
                    StockEOD = null;

                StockEOD = details;

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
    }
}
