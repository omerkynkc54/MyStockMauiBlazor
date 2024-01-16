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
        // Add logic for when the user clicks the login button
        string username = usernameEntry.Text;
        string password = passwordEntry.Text;
        Debug.WriteLine(username + ":" + password);

        // TODO: Add authentication logic
    }

    private async void OnSignupButtonClicked(object sender, EventArgs e)
    {
        // Add logic for when the user clicks the sign up button
        // Usually navigating to a sign-up page or similar
    }
}