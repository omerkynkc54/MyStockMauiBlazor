using MyStockMauiBlazor.Views;
using MyStockMauiBlazor.Data;

namespace MyStockMauiBlazor;
public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        var dbService = new StockDatabase();
        //dbService.CreateTestUserIfNotExistsAsync().Wait();


        MainPage = new NavigationPage(new LoginPage());
    }
}
