using Microsoft.Maui.Controls;
using MyStockMauiBlazor.Data;

namespace MyStockMauiBlazor.Views
{
    public partial class NewTransactionPage : ContentPage
    {
        public NewTransactionPage()
        {
            InitializeComponent();
        }

        private void OnSellClicked(object sender, EventArgs e)
        {
            // Logic for selling stocks
        }
        private async void OnCrudButton1Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewTransactionPage());
        }
        private async void OnMyStocksButton1Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StockViewPage());
        }
        private async void OnProfileButton1Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
        private void OnBuyClicked(object sender, EventArgs e)
        {
            // Assuming you have Entry fields for stockName, unitPrice, and quantity
            string stockName = stockNameEntry.Text;
            decimal unitPrice = decimal.Parse(unitPriceEntry.Text); // Add validation
            int quantity = int.Parse(quantityEntry.Text); // Add validation

            AddTransaction(stockName, unitPrice, quantity);
        }

        private DBDict dbDict;

        // Method to handle adding a transaction
        private void AddTransaction(string stockName, decimal unitPrice, int quantity)
        {
            var stockService = DBDict.Instance;
            //stockService.AddTransaction(stockName, unitPrice, quantity);
            UpdateAveragePriceDisplay(stockName);
        }

        // Method to handle deleting a transaction
        private void DeleteTransaction(string stockName, int transactionIndex)
        {
            //dbDict.DeleteTransaction(stockName, transactionIndex);
            UpdateAveragePriceDisplay(stockName);
        }

        private void UpdateAveragePriceDisplay(string stockName)
        {
            //decimal averagePrice = dbDict.CalculateAverageBuyPrice(stockName);
            // Update your UI here with the calculated averagePrice
            // For example: averagePriceLabel.Text = $"Average Price: {averagePrice:C}";
        }
    }
}