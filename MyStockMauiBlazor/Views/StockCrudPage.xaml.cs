using Microsoft.Maui.Controls;
using MyStockMauiBlazor.Data;

namespace MyStockMauiBlazor.Views
{
    public partial class NewTransactionPage : ContentPage
    {
        public NewTransactionPage()
        {
            InitializeComponent();
            dbDict = new DBDict();
        }

        private void OnSellClicked(object sender, EventArgs e)
        { }
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
            string stockName = stockNameEntry.Text;
            decimal unitPrice = decimal.Parse(unitPriceEntry.Text);
            int quantity = int.Parse(quantityEntry.Text);
            //AddTransaction(stockName, unitPrice, quantity); Not Working
        }

        private DBDict dbDict;
        private void AddTransaction(string stockName, decimal unitPrice, int quantity)
        {
            dbDict.AddTransaction(stockName, unitPrice, quantity);
            UpdateAveragePriceDisplay(stockName);
        }

        private void DeleteTransaction(string stockName, int transactionIndex)
        {
            dbDict.DeleteTransaction(stockName, transactionIndex);
            UpdateAveragePriceDisplay(stockName);
        }
        private void UpdateAveragePriceDisplay(string stockName)
        {
            decimal averagePrice = dbDict.CalculateAverageBuyPrice(stockName);
        }
    }
}