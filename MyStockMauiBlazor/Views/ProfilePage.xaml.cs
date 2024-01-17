using Microsoft.Maui.Controls;

namespace MyStockMauiBlazor.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            // Additional initialization can be done here
        }

        private async void OnCrudButton2Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewTransactionPage());
        }
        private async void OnMyStocksButton2Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StockViewPage());
        }
        private async void OnProfileButton2Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
    }
}