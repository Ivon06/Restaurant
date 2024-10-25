using Microsoft.EntityFrameworkCore;
using RestaurantEntity.Data;
using RestaurantEntity.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEntity.Controllers
{
    public class DishController
    {
        RestaurantDbContext dbContext = new RestaurantDbContext();
        public List<Dish> GetAllDishes()
        {
            var dishes = dbContext.Dishes.ToList();
            return dishes;
        }

        public List<string> GetAllDishIngredients(int dishId)
        {
            var ingredients = dbContext.DishesIngredients
                .Where(di => di.DishId == dishId)
                .Select(di => di.Ingredient.Name)
                .ToList();

            return ingredients;
        }

        public Dish GetDishByName(string name)
        { 
            var dish = dbContext.Dishes.FirstOrDefault(d => d.Name == name);
            
            return dish;
            
        }

        public bool UpdateDishName(string oldName, string newName)
        {
            bool success = true;

            var dish = dbContext.Dishes.FirstOrDefault(d => d.Name == oldName);

            if(dish ==  null)
            {
                return false;
            }
            else
            {
                dish.Name = newName;
            }

            dbContext.SaveChanges();
            return success;
        }

        public bool UpdateDishPrice(string name, string price)
        {
            bool success = true;

            var dish = dbContext.Dishes.FirstOrDefault(d => d.Name == name);

            if (dish == null)
            {
                return false;
            }
            else
            {
                dish.Price = price;
            }

            dbContext.SaveChanges();
            return success;
        }

        public bool UpdateDishIngredients(string name, string ingredient)
        {

            bool success = true;

            var dish = dbContext.Dishes.FirstOrDefault(d => d.Name == name);

            if (dish == null)
            {
                return false;
            }
            else
            {
                var allIngredients = dbContext.Ingredients.Select(i => i.Name).ToList();

                if(allIngredients.Contains(ingredient))
                {
                    int ingredientId = dbContext.Ingredients.FirstOrDefault(i => i.Name == ingredient).Id;
                    DishIngredients di = new DishIngredients()
                    {
                        DishId = dish.Id,
                        IngredientId = ingredientId
                    };

                    dbContext.DishesIngredients.Add(di);
                   
                }
                else
                {
                    Ingredient i = new Ingredient()
                    {
                        Name = ingredient
                    };
                    dbContext.Ingredients.Add(i);
                    int ingredientId = dbContext.Ingredients.FirstOrDefault(i => i.Name == ingredient).Id;
                    DishIngredients di = new DishIngredients()
                    {
                        DishId = dish.Id,
                        IngredientId = ingredientId
                    };

                    dbContext.DishesIngredients.Add(di);

                }
                dbContext.SaveChanges();
                return true;
            }

           
        }

        public bool DeleteDish(string dishName)
        {
            var dish = dbContext.Dishes.FirstOrDefault(d => d.Name == dishName);
            if (dish != null)
            {
                dbContext.Dishes.Remove(dish);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
