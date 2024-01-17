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
        {
            // Logic for selling stocks
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
            dbDict.AddTransaction(stockName, unitPrice, quantity);
            UpdateAveragePriceDisplay(stockName);
        }

        // Method to handle deleting a transaction
        private void DeleteTransaction(string stockName, int transactionIndex)
        {
            dbDict.DeleteTransaction(stockName, transactionIndex);
            UpdateAveragePriceDisplay(stockName);
        }

        private void UpdateAveragePriceDisplay(string stockName)
        {
            decimal averagePrice = dbDict.CalculateAverageBuyPrice(stockName);
            // Update your UI here with the calculated averagePrice
            // For example: averagePriceLabel.Text = $"Average Price: {averagePrice:C}";
        }
    }
}