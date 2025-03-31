namespace MauiApp1.MVVM.Views;

using System.Threading.Tasks;
using MauiApp1.MVVM.Views;
using MauiApp1.MVVM.ViewModels;
using MauiApp1.MVVM.Services;

public partial class LoginPage : ContentPage
{

    public UserService _userService;
    
    public LoginPage(UserService ?userService)
	{
		InitializeComponent();
        _userService = userService;
		BindingContext = new Authenthication(userService);
    }

    private async void RegisterPageButton_Clicked(object sender, EventArgs e)
    {
        await App.Current.MainPage.Navigation.PushAsync(new RegisterPage(_userService));
    }

}