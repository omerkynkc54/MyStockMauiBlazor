using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Maui.Controls;

namespace MyStockMauiBlazor.Views
{
    public partial class StockViewPage : ContentPage
    {
        public ObservableCollection<Stock> Stocks { get; } = new ObservableCollection<Stock>();



        public StockViewPage()
        {
            InitializeComponent();
            LoadMockStockData();
            BindingContext = this;
            crudButton.Clicked += OnCrudButtonClicked;
        }

        private void LoadMockStockData()
        {
            // Load your mock data here
            Stocks.Add(new Stock { Name = "AAPL", Quantity = 10, BuyPrice = 120.00m, CurrentPrice = 140.00m, Profit = 200.00m });
            Stocks.Add(new Stock { Name = "GOOGL", Quantity = 5, BuyPrice = 1000.00m, CurrentPrice = 1200.00m, Profit = 1000.00m });
            // Add more stocks as needed
        }

        private void OnStockTapped(object sender, EventArgs e)
        {
            if (sender is Frame frame && frame.BindingContext is Stock stock)
            {
                stock.IsExpanded = !stock.IsExpanded;
            }
        }
        private async void OnCrudButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewTransactionPage());
        }
    }


    public class Stock : BindableObject
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal Profit { get; set; }

        public decimal Total => Quantity * CurrentPrice;

        private bool _isExpanded;
        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}