using MauiApp1.MVVM.Services;

namespace MauiApp1.MVVM.Views;

public partial class HomePage : ContentPage
{
    private readonly UserService _userService;
	public HomePage(UserService userService)
	{
		InitializeComponent();
		_userService = userService;
	}


	
    private async void LogoutButton_Clicked(object sender, EventArgs e)
    {
		App.Current.MainPage = new NavigationPage(new LoginPage(_userService));
    }
}


