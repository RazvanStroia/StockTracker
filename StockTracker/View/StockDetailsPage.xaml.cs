namespace StockTracker.View;

public partial class StockDetailsPage : ContentPage
{
    public StockDetailsPage(StockDetailsViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }

}