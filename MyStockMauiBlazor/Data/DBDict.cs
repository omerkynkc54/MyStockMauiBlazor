using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockMauiBlazor.Data
{
    public class StockTransaction
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
    public class DBDict
    {
        private static readonly DBDict _instance = new DBDict();
        public static DBDict Instance => _instance;

        private ObservableCollection<Stock> _stocks = new ObservableCollection<Stock>();

        // Ensure the constructor is private so it can't be instantiated from outside.
        private DBDict() { }

        public ObservableCollection<Stock> Stocks => _stocks;
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
}