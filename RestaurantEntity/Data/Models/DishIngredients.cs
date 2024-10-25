using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEntity.Data.Models
{
    public class DishIngredients
    {
        [ForeignKey(nameof(Models.Dish))]
        public int DishId { get; set; }
        public Dish Dish { get; set; }

        [ForeignKey(nameof(Models.Ingredient))]
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
