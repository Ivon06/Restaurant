using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEntity.Data.Models
{
    public class Order
    {
       
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        [ForeignKey(nameof(Models.Client))]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public ICollection<OrderDish> orderDishes { get; set; }
    }
}
