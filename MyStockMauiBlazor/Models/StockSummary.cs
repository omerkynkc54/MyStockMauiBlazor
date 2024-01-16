namespace MyStockMauiBlazor.Models
{
    public class StockSummary
    {
        public string StockCode { get; set; }
        public double AvgBuyPrice { get; set; }
        public double UserStockAmount { get; set; }
        public double ProfitLoss { get; set; }
    }
}