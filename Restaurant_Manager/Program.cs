namespace Restaurant_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            FileDatabaseService fileDatabaseService = new FileDatabaseService();
            StockService stockService = new StockService();
            MenuService menuService = new MenuService();
            OrdersService ordersService = new OrdersService();
            ConsoleUIService consoleUIService = new ConsoleUIService(fileDatabaseService, stockService, menuService, ordersService);

            string[] stockData = fileDatabaseService.ReadStock();
            if (stockData != null)
                stockService.StockList = stockService.ParseStock(stockData);

            string[] menuData = fileDatabaseService.ReadMenu();
            if (menuData != null)
                menuService.MenuList = menuService.ParseMenu(menuData);

            string[] ordersData = fileDatabaseService.ReadOrders();
            if (ordersData != null)
                ordersService.OrdersList = ordersService.ParseOrders(ordersData);

            while (true)
            {
                consoleUIService.PrintMessage(Constants.mainMenuMessage);
                int input = consoleUIService.GetInput();
                consoleUIService.ProcessInput(input);
            }
        }
    }
}
