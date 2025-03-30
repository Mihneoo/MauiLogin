using MauiApp1.MVVM.Services;

namespace MauiApp1.MVVM.Views;

public partial class HomePage : ContentPage
{
	public HomePage(UserService userService)
	{
		InitializeComponent();
	}

    private readonly UserService _userService;
    private void LogoutButton_Clicked(object sender, EventArgs e)
    {
		App.Current.MainPage = new LoginPage(_userService);
    }
}