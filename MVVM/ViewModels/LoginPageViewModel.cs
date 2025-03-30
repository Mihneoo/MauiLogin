using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Windows.Input;
using MauiApp1.MVVM.Views;
using MauiApp1.MVVM.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MauiApp1.MVVM.Services;

namespace MauiApp1.MVVM.ViewModels
{
    class LoginPageViewModel : INotifyPropertyChanged
    {
        public ICommand NavigateToHomePageCommand { get; }

        private ObservableCollection<User> _users;

        public ObservableCollection<User> Users
        {
            get => _users;
            set { _users = value;
                OnPropertyChanged();
            }
        }

        private readonly UserService _userService;
        public LoginPageViewModel(UserService userService)
        {
            _userService = userService;
            NavigateToHomePageCommand = new Command(OnNavigateToHomePage);
        }

        private async void OnNavigateToHomePage()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
