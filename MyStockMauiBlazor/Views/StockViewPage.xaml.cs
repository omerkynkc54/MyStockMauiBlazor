using System.Collections.ObjectModel;

namespace MyStockMauiBlazor.Views;

public partial class StockViewPage : ContentPage
{
        public ObservableCollection<Stock> Stocks { get; set; }

        public StockViewPage()
        {
            InitializeComponent();

            Stocks = new ObservableCollection<Stock>
            {
                new Stock { Name = "AAPL", Quantity = 50, Profit = 200, BuyPrice = 120.00m, CurrentPrice = 130.00m },
                new Stock { Name = "MSFT", Quantity = 30, Profit = 150, BuyPrice = 210.00m, CurrentPrice = 220.00m },
                // Add more stocks as needed
            };

            this.BindingContext = this;
        }

        private void OnAddStockClicked(object sender, EventArgs e)
        {
            // Navigate to the add stock page
        }

        private void OnProfileClicked(object sender, EventArgs e)
        {
            // Navigate to the profile page
        }
    }

    public class Stock
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Profit { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal Total => Quantity * CurrentPrice;
    }

