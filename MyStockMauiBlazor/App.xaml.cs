using MyStockMauiBlazor.Views;
using MyStockMauiBlazor.Data;

namespace MyStockMauiBlazor;
public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new LoginPage());
    }
}
