using RestaurantEntity.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEntity.Views
{
    public class RestaurantView
    {
        private ClientController clientController = new();
        private DishController dishController = new();
        private OrderController orderController = new();
        public void Reastaurant()
        {
            Console.Clear();

            string name = (string)clientController.GetClientById(User.CurrentUserId).Name;

            Console.WriteLine($"Welcome {name}");
            Console.WriteLine("1: LogOut");
            Console.WriteLine("2: My Dishes");
            Console.WriteLine("3: Update dish");
            Console.WriteLine("4: Delete dish");
            Console.WriteLine("5: MyOrders");

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

                    }
                }
                else if (command == 3)
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

                    }

                    Console.WriteLine("Which dish do you want to update?(Enter its name)");
                    string dishName = Console.ReadLine();

                    if (!allDish.Select(d => d.Name).Contains(dishName))
                    {
                        Console.WriteLine("This dosh does not exist. Choose another:");
                        dishName = Console.ReadLine();

                    }

                    Console.WriteLine("What do you want to update: name, price or ingredients?");
                    string update = Console.ReadLine();

                    if (update.ToLower() == "name")
                    {
                        Console.WriteLine("Enter new name");
                        string newName = Console.ReadLine();

                        bool result = dishController.UpdateDishName(dishName, newName);

                        if (result)
                        {
                            var allDish2 = dishController.GetAllDishes();
                            Console.WriteLine("Dish successfully updated!");
                            for (int i = 0; i < allDish2.Count; i++)
                            {
                                var dish = allDish2[i];

                                Console.WriteLine($"{i + 1}. {dish.Name} - {dish.Price}lv");

                                var ingredients = dishController.GetAllDishIngredients(dish.Id);

                                foreach (var ingredient in ingredients)
                                {
                                    Console.WriteLine($"  - {ingredient}");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong. Cannot make changes.");
                        }
                    }
                    else if (update.ToLower() == "price")
                    {
                        Console.WriteLine("Enter new price");
                        string newPrice = Console.ReadLine();

                        bool result = dishController.UpdateDishPrice(dishName, newPrice);

                        if (result)
                        {
                            var allDish2 = dishController.GetAllDishes();
                            Console.WriteLine("Dish successfully updated!");
                            for (int i = 0; i < allDish2.Count; i++)
                            {
                                var dish = allDish2[i];

                                Console.WriteLine($"{i + 1}. {dish.Name} - {dish.Price}lv");

                                var ingredients = dishController.GetAllDishIngredients(dish.Id);

                                foreach (var ingredient in ingredients)
                                {
                                    Console.WriteLine($"  - {ingredient}");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong. Cannot make changes.");
                        }

                    }
                    else if (update.ToLower() == "ingredients")
                    {
                        Console.WriteLine("Enter new ingredient");
                        string ingredient = Console.ReadLine();

                        bool result = dishController.UpdateDishIngredients(dishName, ingredient);

                        if (result)
                        {

                            var allDish2 = dishController.GetAllDishes();
                            Console.WriteLine("Dish successfully updated!");
                            for (int i = 0; i < allDish2.Count; i++)
                            {
                                var dish = allDish2[i];

                                Console.WriteLine($"{i + 1}. {dish.Name} - {dish.Price}lv");

                                var ingredients = dishController.GetAllDishIngredients(dish.Id);

                                foreach (var ingredient1 in ingredients)
                                {
                                    Console.WriteLine($"  - {ingredient1}");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong. Cannot make changes.");
                        }
                    }

                }
                else if(command == 4)
                {
                    var allDish2 = dishController.GetAllDishes();
                    Console.WriteLine("Which dish do you want to delete?(enter its name)");
                    for (int i = 0; i < allDish2.Count; i++)
                    {
                        var dish = allDish2[i];

                        Console.WriteLine($"{i + 1}. {dish.Name} - {dish.Price}lv");

                        var ingredients = dishController.GetAllDishIngredients(dish.Id);

                        foreach (var ingredient in ingredients)
                        {
                            Console.WriteLine($"  - {ingredient}");
                        }
                    }

                    string dishName = Console.ReadLine();
                    var result = dishController.DeleteDish(dishName);

                    if(result)
                    {
                        Console.WriteLine($"Dish {dishName} successfully deleted!");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong.");
                    }
                }
                else if (command == 5)
                {
                    var allOrders = orderController.GetAllOrders();

                    foreach (var order in allOrders)
                    {
                        string clientName = clientController.GetClientNameByOrderId(order.Id);
                        Console.WriteLine($"Client name: {clientName}  Date: {order.OrderDate}");

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

                Console.WriteLine("What is next?");
                Console.WriteLine("1: LogOut");
                Console.WriteLine("2: My Dishes");
                Console.WriteLine("3: Update dish");
                Console.WriteLine("4: Delete dish");
                Console.WriteLine("5: MyOrders");
                command = int.Parse(Console.ReadLine());
            }
        }
    }
}
