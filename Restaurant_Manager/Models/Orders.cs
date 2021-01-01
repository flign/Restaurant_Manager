using System.Collections.Generic;
using System.Threading;

namespace Restaurant_Manager
{
    public class Orders
    {
        private static int orderId;
        public int OrderId { get; private set; }
        public string DateTime { get; set; }
        public string MenuItems { get; set; }

        public Orders(string DateTime, string MenuItems)
        {
            this.DateTime = DateTime;
            this.MenuItems = MenuItems;
            OrderId = Interlocked.Increment(ref orderId);
        }
    }
}