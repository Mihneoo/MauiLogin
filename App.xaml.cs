using MauiApp1.MVVM.Services;
using MauiApp1.MVVM.Views;
using MauiApp1.MVVM.ViewModels;

namespace MauiApp1
{
    public partial class App : Application
    {
        public App(UserService userService)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }
    }
}
