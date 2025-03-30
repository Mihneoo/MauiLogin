using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.MVVM.Models;

namespace MauiApp1.MVVM.Services
{
    public class UserService : INotifyPropertyChanged
    {
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>()
        {
            new User("admin", "password"),// Pre-populate if needed
            new User("admin123", "password123") // Pre-populate if needed
        };

        public bool ValidateUser(string username, string password)
        {
            return Users.Any(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && // [[8]][[9]]
                u.Password == password);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
