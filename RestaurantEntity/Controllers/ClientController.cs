using RestaurantEntity.Data;
using RestaurantEntity.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEntity.Controllers
{
    public class ClientController
    {
        private RestaurantDbContext dbContext = new();
        private OrderController orderController = new();

        public Client GetClientById(int id)
        {
            var cllient = dbContext.Clients.FirstOrDefault(c => c.Id == id);

            return cllient;
        }

        public string GetClientNameByOrderId(int orderId)
        {
            var order = orderController.GetOrderById(orderId);

            Client client = GetClientById(order.ClientId);
            order.Client = client;

            string name = order.Client.Name;

            return name;
        }
    }
}
