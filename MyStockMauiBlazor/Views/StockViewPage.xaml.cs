using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Controls;

namespace MyStockMauiBlazor.Views;

public partial class StockViewPage : ContentPage
{
    public ObservableCollection<Stock> Stocks { get; } = new ObservableCollection<Stock>();

    public StockViewPage()
    {
        InitializeComponent();
        LoadMockStockData();
        BindingContext = this;
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
        // Load your mock data here
        var stockAAPL = new Stock { Name = "AAPL", CurrentPrice = 140.00m };
        var stockGOOGL = new Stock { Name = "GOOGL", CurrentPrice = 1200.00m };

        stockAAPL.AddTransaction(new StockTransaction { UnitPrice = 120.00m, Quantity = 10 });
        stockGOOGL.AddTransaction(new StockTransaction { UnitPrice = 1000.00m, Quantity = 5 });

        // Add the stocks to the ObservableCollection
        Stocks.Add(stockAAPL);
        Stocks.Add(stockGOOGL);
    }
    private void OnStockTapped(object sender, EventArgs e)
    {
        if (sender is Frame frame && frame.BindingContext is Stock stock)
        {
            stock.IsExpanded = !stock.IsExpanded;
    
        }
    }

    // Rest of your StockViewPage code...
}

public class Stock : BindableObject
{
    private List<StockTransaction> _transactions = new List<StockTransaction>();

    public string Name { get; set; }
    public int Quantity => _transactions.Sum(tr => tr.Quantity);
    public decimal BuyPrice => CalculateAverageBuyPrice();
    public decimal CurrentPrice { get; set; }
    public decimal Profit => (CurrentPrice - BuyPrice) * Quantity;
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

    private decimal CalculateAverageBuyPrice()
    {
        var totalCost = _transactions.Sum(tr => tr.UnitPrice * tr.Quantity);
        var totalQuantity = _transactions.Sum(tr => tr.Quantity);
        return totalQuantity > 0 ? totalCost / totalQuantity : 0;
    }

    public void AddTransaction(StockTransaction transaction)
    {
        _transactions.Add(transaction);
        OnPropertyChanged(nameof(BuyPrice));
        OnPropertyChanged(nameof(Quantity));
        OnPropertyChanged(nameof(Profit));
        OnPropertyChanged(nameof(Total
            ));
    }
}

public class StockTransaction
{
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}