using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiApp1.MVVM.Models;
using MauiApp1.MVVM.Services;
using MauiApp1.MVVM.Views;

namespace MauiApp1.MVVM.ViewModels
{
    public class Authenthication : INotifyPropertyChanged
    {
        private string _password = string.Empty;
        private string _confirmPassword = string.Empty;
        private string _errorMessage = string.Empty;
        private string _username = string.Empty;

        [Required]
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }
        [Required]
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        [Required, Compare(nameof(Password))]
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }


        public ICommand NavigateToHomePageCommand { get; }
        public ICommand RegisterCommand { get; }




        public UserService _userService;
        public Authenthication(UserService userService)
        { 
            _userService = userService;
            NavigateToHomePageCommand = new Command(OnNavigateToHomePage);
            RegisterCommand = new Command(OnRegister);

        }

        private async void OnRegister()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(ConfirmPassword))
                {
                    throw new ArgumentNullException("All fields are required.");
                }

                if (Password != ConfirmPassword)
                {
                    ErrorMessage = "Passwords do not match!";
                    await App.Current.MainPage.DisplayAlert("Error", ErrorMessage, "OK");
                    return;
                }

                _userService?.Users.Add(new User(Username, Password));
                ErrorMessage = "User Added";
                await App.Current.MainPage.DisplayAlert("Success", ErrorMessage, "OK");

                await App.Current.MainPage.Navigation.PopAsync();
            }
            catch (ArgumentNullException ex)
            {
                ErrorMessage = ex.Message;
                await App.Current.MainPage.DisplayAlert("Error", ErrorMessage, "OK");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                await App.Current.MainPage.DisplayAlert("Error", ErrorMessage, "OK");
            }


        }

       
        private async void OnNavigateToHomePage()
        {

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Username and password are required!";
                await App.Current.MainPage.DisplayAlert("Error", ErrorMessage, "OK");
                return;
            }

            if (!_userService.ValidateUser(Username, Password)) // Trim whitespace [[5]]
            {
                ErrorMessage = "Invalid username or password!";
                await App.Current.MainPage.DisplayAlert("Error", ErrorMessage, "OK");
                return;
            }

            App.Current.MainPage = new HomePage(_userService);

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
