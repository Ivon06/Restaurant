using RestaurantEntity.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEntity.Controllers
{
    public static class User
    {
        static HomeView home = new HomeView();
        public static int CurrentUserId { get; private set; }


        public static void SetCurrentUser(int userId)
        {
            CurrentUserId = userId;
        }

        public static void Logout()
        {
            CurrentUserId = 0;
            home.Home();
        }

        public static bool IsUserLoggedIn()
        {
            return CurrentUserId > 0;
        }
    }
}
