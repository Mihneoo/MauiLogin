namespace MauiApp1.MVVM.Views;

using System.Threading.Tasks;
using MauiApp1.MVVM.Views;
using MauiApp1.MVVM.ViewModels;
using MauiApp1.MVVM.Services;

public partial class LoginPage : ContentPage
{

    
    public LoginPage(UserService ?userService)
	{
		InitializeComponent();
		BindingContext = new Authenthication(userService);
    }

    private readonly UserService _userService;
    private async void RegisterPageButton_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new RegisterPage(_userService);
    }

}