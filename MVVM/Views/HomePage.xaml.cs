using System.Threading.Tasks;
using MauiApp1.MVVM.Services;

namespace MauiApp1.MVVM.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private readonly UserService _userService;
    private async void LogoutButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopToRootAsync();
    }
}