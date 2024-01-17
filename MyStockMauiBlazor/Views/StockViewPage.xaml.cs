using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Controls;
using MyStockMauiBlazor.Data;

namespace MyStockMauiBlazor.Views;

public partial class StockViewPage : ContentPage
{
    private ObservableCollection<Stock> Stocks =DBDict.Instance.Stocks;
    public StockViewPage()
    {
        InitializeComponent();
        LoadMockStockData();
        BindingContext = this;
    }
    public void AddNewStock(Stock newStock)
    {
        var stockService = DBDict.Instance;
        stockService.Stocks.Add(newStock);
    }
    private async void OnCrudButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewTransactionPage());
    }
    private async void OnMyStocksButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new StockViewPage());
    }
    private async void OnProfileButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProfilePage());
    }
    private void LoadMockStockData()
    {
        var stockService = DBDict.Instance;
        // Load your mock data here
        var stockAAPL = new Stock { Name = "AAPL", CurrentPrice = 147.00m };
        var stockGOOGL = new Stock { Name = "GOOGL", CurrentPrice = 1200.00m };

        stockAAPL.AddTransaction(new StockTransaction { UnitPrice = 120.00m, Quantity = 10 });
        stockGOOGL.AddTransaction(new StockTransaction { UnitPrice = 1000.00m, Quantity = 5 });

        // Add the stocks to the ObservableCollection
        Stocks.Add(stockAAPL);
        stockService.Stocks.Add(stockGOOGL);
    }
    private void OnStockTapped(object sender, EventArgs e)
    {
        if (sender is Frame frame && frame.BindingContext is Stock stock)
        {
            stock.IsExpanded = !stock.IsExpanded;
    
        }
    }
}