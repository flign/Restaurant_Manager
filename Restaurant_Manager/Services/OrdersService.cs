using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant_Manager
{
    public class OrdersService
    {
        public List<Orders> OrdersList { get; set; }

        public OrdersService()
        {
            OrdersList = new List<Orders>();
        }

        public List<Orders> ParseOrders(string[] orders)
        {
            List<Orders> ordersList = new List<Orders>();

            if (orders?[0] == string.Empty)
                return ordersList;

            foreach (string order in orders)
            {
                string[] ordersData = order.Split(',');
                var temp = new Orders(ordersData[1], ordersData[2]);
                ordersList.Add(temp);
            }

            return ordersList;
        }

        public void AddOrder(string dateTime, string menuItems)
        {
            if(menuItems == "ERROR")
                return;
            Orders order = new Orders(dateTime, menuItems);
            OrdersList.Add(order);
        }

        public Orders GetOrderById(int Id) => OrdersList.Where(c => c.OrderId == Id).FirstOrDefault();

        public void DeleteOrder(Orders order)
        {
            OrdersList.Remove(order);
        }

        public string GetOrdersData()
        {
            string orderData = string.Empty;

            foreach (Orders order in OrdersList)
            {
                orderData += string.Format($"{order.OrderId},{order.DateTime},{order.MenuItems}\n");
            }
            return orderData;
        }
    }
}
