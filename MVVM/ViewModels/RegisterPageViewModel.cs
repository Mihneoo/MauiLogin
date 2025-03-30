using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiApp1.MVVM.Models;
using MauiApp1.MVVM.Services;

namespace MauiApp1.MVVM.ViewModels
{
    public  class RegisterPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public ICommand RegisterCommand { get; }

        public bool Validate;

        private readonly UserService _userService;
        public RegisterPageViewModel(UserService userService)
        {
            _userService = userService;
            Validate = false;
            RegisterCommand = new Command(OnRegister);
        }

        private async void OnRegister()
        {
            if (true)
            {


                // Add new user logic here (e.g., validate input, save to Users)
                Users.Add(new User("newUser", "pass123")); // Example

                // Navigate back to LoginPage
                await App.Current.MainPage.Navigation.PopAsync(); 
                
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
