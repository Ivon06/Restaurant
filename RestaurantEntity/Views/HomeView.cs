using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantEntity.Controllers;

namespace RestaurantEntity.Views
{
    public class HomeView
    {
        private AccountController accountController = new();
        public void Home()
        {
            Console.WriteLine("For login type: 1");
            Console.WriteLine("For register type: 2");

            if (int.Parse(Console.ReadLine()) == 1)
            {
                Console.WriteLine("Enter email");
                string email = Console.ReadLine();
                Console.WriteLine("Enter password");
                string password = Console.ReadLine();

                accountController.LogIn(email, password);

              
            }
            else 
            {
                Console.WriteLine("Enter email");
                string email = Console.ReadLine();
                Console.WriteLine("Enter name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter password");
                string password = Console.ReadLine();


               var result = accountController.Register(name, email, password);

                if(!result)
                {
                    Console.WriteLine("This user is already registered.");
                    Console.WriteLine("Enter email");
                    string email1 = Console.ReadLine();
                    Console.WriteLine("Enter name");
                    string name1 = Console.ReadLine();
                    Console.WriteLine("Enter password");
                    string password1 = Console.ReadLine();


                     result= accountController.Register(name1, email1, password1);
                }
            }
        }

        public void NotRegistered()
        {
            Console.WriteLine("This user is not registered.");
            this.Home();
        }
    }
}
