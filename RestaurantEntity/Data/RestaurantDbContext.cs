using Microsoft.EntityFrameworkCore;
using RestaurantEntity.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEntity.Data
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; } 
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDish> OrdersDishes { get; set; }
        public DbSet<DishIngredients> DishesIngredients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDish>().HasKey(s => new { s.OrderId, s.DishId });
            modelBuilder.Entity<DishIngredients>().HasKey(s => new { s.IngredientId, s.DishId });

            
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-563OQUI\\MSSQLSERVER01;Database=restaurantEntity; Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
