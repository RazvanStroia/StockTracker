using StockTracker.View;

namespace StockTracker
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(StockDetailsPage), typeof(StockDetailsPage));
        }
    }
}
