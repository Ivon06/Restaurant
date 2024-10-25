using Microsoft.EntityFrameworkCore;
using RestaurantEntity.Data;
using RestaurantEntity.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEntity.Controllers
{
    public class OrderController
    {
        private RestaurantDbContext dbContext = new();
        private DishController dishController = new DishController();
        public void CreateOrder(int clientId, DateTime date)
        {
            Order order = new Order()
            {
                ClientId = clientId,
                OrderDate = date
            };

            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
        }

        public int GetOrderId(int clientId, DateTime date)
        {
            var id = dbContext.Orders.FirstOrDefault(o =>  o.ClientId == clientId && o.OrderDate == date).Id;
            return id;
        }

        public bool AddDishToOrder(string dishName, int orderId)
        {
            var order = dbContext.Orders.FirstOrDefault(o => o.Id == orderId);
            var dish = dishController.GetDishByName(dishName);

            if (order != null && dish != null)
            {
                OrderDish od = new OrderDish()
                {
                    DishId = dish.Id,
                    //Dish = dish,
                    OrderId = orderId,
                   // Order = order
                };
                dbContext.OrdersDishes.Add(od);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Order> GetAllClientOrders(int clientId)
        {
            var orders = dbContext.Orders.Where(o => o.ClientId == clientId).ToList();

            return orders;
        }

        public List<Dish> GetOrderDishes(int orderId)
        {
            var dishes = dbContext.OrdersDishes.Where(od => od.OrderId == orderId).Select(od => od.Dish).ToList();
            return dishes;
        }

        public List<Order> GetAllOrders()
        {
            var orders = dbContext.Orders.ToList();

            return orders;
        }

        public Order GetOrderById(int id)
        {
            var order = dbContext.Orders.FirstOrDefault(o => o.Id == id);
            return order;
        }
    }
}
