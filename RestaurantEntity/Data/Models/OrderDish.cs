using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEntity.Data.Models
{
    public class OrderDish
    {
        [ForeignKey(nameof(Models.Order))]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey(nameof(Models.Dish))]
        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
