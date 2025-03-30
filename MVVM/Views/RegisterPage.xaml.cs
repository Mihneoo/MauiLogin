using System.Threading.Tasks;
using MauiApp1.MVVM.Services;
using MauiApp1.MVVM.ViewModels;
using Microsoft.Extensions.Options;

namespace MauiApp1.MVVM.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
		BindingContext = new Authentication();


    }


   
}