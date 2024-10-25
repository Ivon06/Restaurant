using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantEntity.Data;
using RestaurantEntity.Data.Models;
using RestaurantEntity.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEntity.Controllers
{
    public class AccountController
    {
        private RestaurantDbContext dbContext = new();
        ClientView accountView = new();
        RestaurantView restaurantView = new();
        public void LogIn(string email, string password)
        {
            var user = dbContext.Clients.FirstOrDefault(c => c.Email == email);
            if (user == null)
            {
                HomeView view = new HomeView();
                view.NotRegistered();
            }
            else
            {
                User.SetCurrentUser(user.Id);
            }

            if (email == "restaurant@abv.bg")
            {
                restaurantView.Reastaurant();
            }
            else
            {
                accountView.Client();
            }
        }

        public bool Register(string name, string email, string password)
        {
            var result = IsExistByEmail(email);

            if (result)
            {
                return false;
            }
            else
            {
                var user = new Client()
                {
                    Name = name,
                    Email = email,
                    Password = password
                };

                dbContext.Clients.Add(user);
                dbContext.SaveChanges();

                this.LogIn(email, password);
                return true;
            }
        }

        
        public void LogOut()
        {
            User.Logout();
        }

        public bool IsExistByEmail(string email)
        {
            var result = dbContext.Clients.Select(c => c.Email).Contains(email);
            return result;

        }
    }
}
