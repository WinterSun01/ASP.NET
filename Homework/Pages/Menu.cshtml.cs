using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Homework.Models;
using Homework.Services;

namespace Homework.Pages
{
    public class MenuModel : PageModel
    {
        private readonly RestaurantMenuService _menuService;

        public MenuModel(RestaurantMenuService menuService)
        {
            _menuService = menuService;
        }

        public List<MenuItem> MenuItems { get; private set; }

        public void OnGet()
        {
            MenuItems = _menuService.GetMenuItems();
        }
    }
}
