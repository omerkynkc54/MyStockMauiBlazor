﻿using MyStockMauiBlazor.Views;
namespace MyStockMauiBlazor

{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }
    }
}
