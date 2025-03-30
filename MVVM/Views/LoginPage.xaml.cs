namespace MauiApp1.MVVM.Views;

using System.Threading.Tasks;
using MauiApp1.MVVM.Views;
using MauiApp1.MVVM.ViewModels;
using MauiApp1.MVVM.Services;

public partial class LoginPage : ContentPage
{

    
    public LoginPage()
	{
		InitializeComponent();
		BindingContext = new Authentication();
    }

    private readonly UserService _userService;
    private async void RegisterPageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }

}