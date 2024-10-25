using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEntity.Data.Models
{
    public class Dish
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public decimal Weight { get; set; }
        public ICollection<DishIngredients> DishIngredients { get; set; }

    }
}
