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
    public class Authentication : INotifyPropertyChanged
    {
        private readonly ObservableCollection<User> _users = new()
    {
        new User("admin", "password"), // Pre-populated users
        new User("admin123", "password123")
    };

        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateToHomePageCommand { get; }
        public ICommand RegisterCommand { get; }

        public Authentication()
        {
            NavigateToHomePageCommand = new Command(OnNavigateToHomePage);
            RegisterCommand = new Command(OnRegister);
        }

        private bool ValidateUser(string username, string password)
        {
            return _users.Any(u =>
                u.Username.Trim().Equals(username.Trim(), StringComparison.OrdinalIgnoreCase) &&
                u.Password.Trim() == password.Trim());
        }

        private async void OnNavigateToHomePage()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Username and password are required!", "OK");
                return;
            }

            if (!ValidateUser(Username, Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Invalid username or password!", "OK");
                return;
            }

            await App.Current.MainPage.Navigation.PushAsync(new HomePage());
        }

        private async void OnRegister()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "All fields are required!", "OK");
                return;
            }

            if (_users.Any(u => u.Username.Equals(Username, StringComparison.OrdinalIgnoreCase)))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Username already exists!", "OK");
                return;
            }

            _users.Add(new User(Username, Password));
            await App.Current.MainPage.DisplayAlert("Success", "User registered successfully!", "OK");

            await App.Current.MainPage.Navigation.PopAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
