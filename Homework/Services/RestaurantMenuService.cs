using System.Collections.Generic;
using Homework.Models;

namespace Homework.Services
{
    public class RestaurantMenuService
    {
        public List<MenuItem> GetMenuItems()
        {
            return new List<MenuItem>
            {
                new MenuItem { Id = 1, Name = "Паста Карбонара", Price = 450 },
                new MenuItem { Id = 2, Name = "Стейк Рибай", Price = 1200 },
                new MenuItem { Id = 3, Name = "Салат Цезарь", Price = 350 },
                new MenuItem { Id = 4, Name = "Тирамису", Price = 300 },
                new MenuItem { Id = 5, Name = "Капучино", Price = 200 }
            };
        }
    }
}
