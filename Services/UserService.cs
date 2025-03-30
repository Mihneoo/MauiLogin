using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.MVVM.Models;

namespace MauiApp1.MVVM.Services
{
    public class UserService
    {
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>()
        {
            new User("admin", "password"),// Pre-populate if needed
            new User("admin123", "password123") // Pre-populate if needed
        };

        public UserService() 
        
        {
            Users = new ObservableCollection<User>();
        }

        public bool ValidateUser(string username, string password)
        {
            return Users.Any(u => u.Username.Trim() == username.Trim() && u.Password.Trim() == password.Trim());
        }

    }
}
