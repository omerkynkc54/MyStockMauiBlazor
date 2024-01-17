using System;
using System.Diagnostics;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;

namespace MyStockMauiBlazor.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();

        loginButton.Clicked += OnLoginButtonClicked;
        signupButton.Clicked += OnSignupButtonClicked;
    }
    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string username = usernameEntry.Text;
        string password = passwordEntry.Text;

        bool isAuth = true;

        //isAuth = await _dbService.AuthenticateUserAsync(username, password); NOT WORKING
        if (isAuth)
        {
            await Navigation.PushAsync(new StockViewPage());
            Navigation.RemovePage(this);
        }
        else
        {
            //errorLabel.text = "error occured"
        }
    }

    private async void OnSignupButtonClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("Signup Button Click");
    }
}