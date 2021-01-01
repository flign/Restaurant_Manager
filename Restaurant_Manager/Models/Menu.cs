using System.Collections.Generic;
using System.Threading;

namespace Restaurant_Manager
{
    public class Menu
    {
        private static int menuId;
        public int MenuId { get; private set; }
        public string Name { get; set; }
        public string Products { get; set; }

        public Menu(string Name, string Products)
        {
            this.Name = Name;
            this.Products = Products;
            MenuId = Interlocked.Increment(ref menuId);
        }
    }
}
