namespace StockTracker.View
{
    public partial class MainPage : ContentPage
    {

        public MainPage(StockViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}
