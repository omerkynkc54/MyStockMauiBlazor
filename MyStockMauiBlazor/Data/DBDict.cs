using System;
using System.Collections.Generic;
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
        private Dictionary<string, List<StockTransaction>> stockTransactions;

        public DBDict()
        {
            stockTransactions = new Dictionary<string, List<StockTransaction>>();
        }

        public void AddTransaction(string stockName, decimal unitPrice, int quantity)
        {
            var transaction = new StockTransaction { UnitPrice = unitPrice, Quantity = quantity };

            if (!stockTransactions.ContainsKey(stockName))
            {
                stockTransactions[stockName] = new List<StockTransaction>();
            }
            stockTransactions[stockName].Add(transaction);
        }

        public void DeleteTransaction(string stockName, int transactionIndex)
        {
            if (stockTransactions.ContainsKey(stockName) && transactionIndex < stockTransactions[stockName].Count)
            {
                stockTransactions[stockName].RemoveAt(transactionIndex);
            }
        }

        public decimal CalculateAverageBuyPrice(string stockName)
        {
            if (stockTransactions.ContainsKey(stockName) && stockTransactions[stockName].Any())
            {
                var totalCost = stockTransactions[stockName].Sum(tr => tr.UnitPrice * tr.Quantity);
                var totalQuantity = stockTransactions[stockName].Sum(tr => tr.Quantity);
                return totalQuantity > 0 ? totalCost / totalQuantity : 0;
            }
            return 0;
        }
    }
}