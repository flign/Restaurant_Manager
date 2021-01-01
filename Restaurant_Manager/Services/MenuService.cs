using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant_Manager
{
    public class MenuService
    {
        public List<Menu> MenuList { get; set; }

        public MenuService()
        {
            MenuList = new List<Menu>();
        }

        public List<Menu> ParseMenu(string[] menu)
        {
            List<Menu> menuList = new List<Menu>();

            if (menu?[0] == string.Empty)
                return menuList;

            foreach (string menuCount in menu)
            {
                string[] menuData = menuCount.Split(',');
                var temp = new Menu(menuData[1], menuData[2]);
                menuList.Add(temp);
            }

            return menuList;
        }

        public void AddMenu(string name, string products)
        {
            if (MenuList.Any(s => s.Name == name))
            {
                Console.WriteLine(Constants.invalidParameterMessage);
                return;
            }
            Menu menu = new Menu(name, products);
            MenuList.Add(menu);
        }

        public Menu GetMenuById(int Id) => MenuList.Where(c => c.MenuId == Id).FirstOrDefault();

        public void UpdateMenu(Menu menu, string name, string products)
        {
            if (!(name.Equals(string.Empty)) && !(products.Equals(string.Empty)))
                menu.Name = name;
            menu.Products = products;
        }
        public void UpdateMenuName(Menu menu, string name)
        {
            if (!(name.Equals(string.Empty)))
                menu.Name = name;
        }
        public void UpdateProducts(Menu menu, string products)
        {
            if (!(products.Equals(string.Empty)))
                menu.Products = products;
        }
        public void DeleteMenu(Menu menu)
        {
            MenuList.Remove(menu);
        }
        public string GetMenuData()
        {
            string menuData = string.Empty;

            foreach (Menu menu in MenuList)
            {
                menuData += string.Format($"{menu.MenuId},{menu.Name},{menu.Products}\n");
            }

            return menuData;
        }
    }
}
