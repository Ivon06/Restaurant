using RestaurantEntity.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RestaurantEntity.Views
{
    public class ClientView
    {
        private ClientController clientController = new();
        private DishController dishController = new();
        private OrderController orderController = new();
        
        public void Client()
        {

            Console.Clear();

            string name = (string)clientController.GetClientById(User.CurrentUserId).Name;

            Console.WriteLine($"Welcome {name}");
            Console.WriteLine("1: LogOut");
            Console.WriteLine("2: Order");
            Console.WriteLine("3: MyOrders");

            int command = int.Parse(Console.ReadLine());

            while (command != 0)
            {
                if (command == 1)
                {
                    Console.Clear();
                    User.Logout();

                }
                else if (command == 2)
                {
                    Order();
                }
                else if (command == 3)
                {

                    var orders = orderController.GetAllClientOrders(User.CurrentUserId);

                    if (orders.Count == 0)
                    {
                        Console.WriteLine("There are no orders.");
                    }
                    else
                    {
                        foreach (var order in orders)
                        {
                            Console.WriteLine(order.OrderDate);

                            var orderDishes = orderController.GetOrderDishes(order.Id);

                            double sum = 0;

                            foreach (var dish in orderDishes)
                            {
                                sum += double.Parse(dish.Price);

                                Console.WriteLine($"  - {dish.Name}     {dish.Price}lv");
                            }
                            Console.WriteLine($"Total: {sum}lv");

                            Console.WriteLine();
                        }
                    }

                }
                

                command = int.Parse(Console.ReadLine());


            }
        }
        public void Order()
        {

            var allDish = dishController.GetAllDishes();

            if (allDish.Count == 0)
            {
                Console.WriteLine("There are no dish for order");
            }
            else
            {
                for (int i = 0; i < allDish.Count; i++)
                {
                    var dish = allDish[i];

                    Console.WriteLine($"{i + 1}. {dish.Name} - {dish.Price}lv");

                    var ingredients = dishController.GetAllDishIngredients(dish.Id);

                    foreach (var ingredient in ingredients)
                    {
                        Console.WriteLine($"  - {ingredient}");
                    }
                }

                Console.WriteLine();


                DateTime date = DateTime.Now;

                Console.WriteLine("Type dish name or Finish Order(type Order):");
                var dishName = Console.ReadLine();

                orderController.CreateOrder(User.CurrentUserId, date);
                int orderId = orderController.GetOrderId(User.CurrentUserId, date);

                while (dishName != "Order")
                {
                    var result = orderController.AddDishToOrder(dishName, orderId);

                    if (result)
                    {
                        Console.WriteLine("Successfully added to order.");
                    }
                    else
                    {
                        Console.WriteLine("Cannot add this to order.");
                    }
                    Console.WriteLine("Type dish name or Finish Order(type Order):");
                    dishName = Console.ReadLine();

                }

                Console.WriteLine("Order is preparing :)");
                Thread.Sleep(2000);
                Client();
            }


        }

        

    }
}
