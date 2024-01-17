using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using Microsoft.Maui.Controls;

namespace MyStockMauiBlazor.Views;

public partial class StockViewPage : ContentPage
{
    private readonly string _apiToken = "LAYQgGjEapzLzWhEhepvEHzNAF7KjME8ukVqfdmL"; // Use your API token here
    private HttpClient _httpClient = new HttpClient();
    public ObservableCollection<Stock> Stocks { get; } = new ObservableCollection<Stock>();

    public StockViewPage()
    {
        InitializeComponent();
        LoadMockStockData();
        BindingContext = this;
        foreach (var stock in Stocks)
        {
            stock.UpdatePriceFromApi(_httpClient, _apiToken);
        }
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
        var stockTSLA = new Stock { Name = "TSLA", CurrentPrice = 1200.00m };
        var stockMSFT = new Stock { Name = "MSFT", CurrentPrice = 1200.00m };

        stockAAPL.AddTransaction(new StockTransaction { UnitPrice = 120.00m, Quantity = 10 });
        stockTSLA.AddTransaction(new StockTransaction { UnitPrice = 1000.00m, Quantity = 5 });
        stockMSFT.AddTransaction(new StockTransaction { UnitPrice = 1000.00m, Quantity = 5 });
        stockMSFT.AddTransaction(new StockTransaction { UnitPrice = 850.00m, Quantity = 7 });
        stockTSLA.AddTransaction(new StockTransaction { UnitPrice = 1200.00m, Quantity = -2 });

        // Add the stocks to the ObservableCollection
        Stocks.Add(stockAAPL);
        Stocks.Add(stockTSLA);
        Stocks.Add(stockMSFT);
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

    private decimal _currentPrice;

    public string Name { get; set; }
    public int Quantity => _transactions.Sum(tr => tr.Quantity);
    public decimal BuyPrice => CalculateAverageBuyPrice();

    public decimal CurrentPrice
    {
        get => _currentPrice;
        set
        {
            if (_currentPrice != value)
            {
                _currentPrice = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Profit)); // Notify that Profit has changed
                OnPropertyChanged(nameof(Total));  // Notify that Total has changed
            }
        }
    }

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
    public async Task UpdatePriceFromApi(HttpClient httpClient, string apiToken)
    {
        string endpoint = $"https://api.stockdata.org/v1/data/quote?symbols={Name}&api_token={apiToken}";
        await Task.Delay(3000);
        var response = await httpClient.GetFromJsonAsync<StockDataResponse>(endpoint);

        if (response?.Data != null)
        {
            var stockQuote = response.Data.FirstOrDefault();
            if (stockQuote != null && stockQuote.Ticker == Name)
            {
                CurrentPrice = (decimal)stockQuote.Price;
                OnPropertyChanged(nameof(CurrentPrice));
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
public class StockDataResponse
{
    public StockQuote[] Data { get; set; }
}

public class StockQuote
{
    public string Ticker { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public StockQuote()
    {
        Ticker = string.Empty;
        Name = string.Empty;
        Price = 0.0;
    }
}