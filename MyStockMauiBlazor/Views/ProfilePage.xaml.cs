using Microsoft.Maui.Controls;

namespace MyStockMauiBlazor.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
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