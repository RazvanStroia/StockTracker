using StockTracker.ViewModel;

namespace StockTracker.View;

public partial class StockSearchPage : ContentPage
{
	public StockSearchPage(StockSearchViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}