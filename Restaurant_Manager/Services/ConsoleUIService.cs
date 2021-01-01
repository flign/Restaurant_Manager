using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Restaurant_Manager
{
    public class ConsoleUIService
    {
        private readonly FileDatabaseService _fileDatabaseService;
        private readonly StockService _stockService;
        private readonly MenuService _menuService;
        private readonly OrdersService _ordersService;

        public ConsoleUIService(FileDatabaseService fileDatabaseService, StockService stockService, MenuService menuService, OrdersService ordersService)
        {
            _fileDatabaseService = fileDatabaseService;
            _stockService = stockService;
            _menuService = menuService;
            _ordersService = ordersService;
    }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public int GetInput()
        {
            bool success = int.TryParse(Console.ReadLine(), out int input);

            if (!success)
                PrintMessage(Constants.invalidParameterMessage);
            return input;
        }
        public void ProcessInput(int input)
        {
            switch (input)
            {
                case 1:
                    {
                        Console.Clear();
                        do
                        {
                            PrintMessage(Constants.stockMenuMessage);
                        } while (ProcessStockInput(GetInput()));
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        do
                        {
                            PrintMessage(Constants.restaurantMenuMessage);
                        } while (ProcessMenuInput(GetInput()));
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        do
                        {
                            PrintMessage(Constants.ordersMenuMessage);
                        } while (ProcessOrdersInput(GetInput()));
                        break;
                    }
                case 4:
                    {
                        System.Environment.Exit(1);
                        break;
                    }
                default:
                    {
                        PrintMessage(Constants.invalidInputMessage);
                        break;
                    }
            }

        }
        public bool ProcessStockInput(int input)
        {
            switch (input)
            {
                case 1:
                    {
                        _stockService.AddStock(NameInput(), PortionCountInput(), UnitInput(), PortionSizeInput());
                        string data = _stockService.GetStockData();
                        _fileDatabaseService.UpdateFile1(data);
                        PrintMessage(Constants.successMessage);
                        return true;
                    }
                case 2:
                    {
                        PrintMessage(Constants.stockUpdateMessage);
                        int stockId = int.Parse(Console.ReadLine());
                        Stock stock = _stockService.GetStockById(stockId);
                        if (stock == null)
                            PrintMessage(Constants.idNotFoundMessage);
                        else
                        {
                            UpdateStock(stock);
                            PrintMessage(Constants.successMessage);
                        }
                        return true;
                    }
                case 3:
                    {
                        PrintMessage(Constants.stockDeleteMessage);
                        int stockId = int.Parse(Console.ReadLine());
                        Stock stock = _stockService.GetStockById(stockId);
                        if (stock == null)
                            PrintMessage(Constants.idNotFoundMessage);
                        else
                        {
                            _stockService.DeleteStock(stock);
                            string data = _stockService.GetStockData();
                            _fileDatabaseService.UpdateFile1(data);
                            PrintMessage(Constants.successMessage);
                        }
                        return true;
                    }
                case 4:
                    {
                        List<Stock> stock = _stockService.StockList;
                        PrintAllStock(stock);
                        return true;
                    }
                case 5:
                    {
                        Console.Clear();
                        return false;
                    }
                default:
                    {
                        PrintMessage(Constants.invalidInputMessage);
                        return true;
                    }

            }
        }
        public bool ProcessMenuInput(int input)
        {
            switch (input)
            {
                case 1:
                    {
                        _menuService.AddMenu(NameInput(), ProductsInput());
                        string data = _menuService.GetMenuData();
                        _fileDatabaseService.UpdateFile2(data);
                        PrintMessage(Constants.successMessage);
                        return true;
                    }
                case 2:
                    {
                        PrintMessage(Constants.menuUpdateMessage);
                        int menuId = int.Parse(Console.ReadLine());
                        Menu menu = _menuService.GetMenuById(menuId);
                        if (menu == null)
                            PrintMessage(Constants.idNotFoundMessage);
                        else
                        {
                            UpdateMenu(menu);
                            PrintMessage(Constants.successMessage);
                        }
                        return true;
                    }
                case 3:
                    {
                        PrintMessage(Constants.menuDeleteMessage);
                        int menuId = int.Parse(Console.ReadLine());
                        Menu menu = _menuService.GetMenuById(menuId);
                        if (menu == null)
                            PrintMessage(Constants.idNotFoundMessage);
                        else
                        {
                            _menuService.DeleteMenu(menu);
                            string data = _menuService.GetMenuData();
                            _fileDatabaseService.UpdateFile2(data);
                            PrintMessage(Constants.successMessage);
                        }
                        return true;
                    }
                case 4:
                    {
                        List<Menu> menu = _menuService.MenuList;
                        PrintAllMenu(menu);
                        return true;
                    }
                case 5:
                    {
                        Console.Clear();
                        return false;
                    }
                default:
                    {
                        PrintMessage(Constants.invalidInputMessage);
                        return true;
                    }

            }
        }
        public bool ProcessOrdersInput(int input)
        {
            switch (input)
            {
                case 1:
                    {
                        _ordersService.AddOrder(DateNow(), MenuItemsInput());
                        string data = _ordersService.GetOrdersData();
                        _fileDatabaseService.UpdateFile3(data);
                        string data2 = _stockService.GetStockData();
                        _fileDatabaseService.UpdateFile1(data2);

                        return true;
                    }
                case 2:
                    {
                        List<Orders> order = _ordersService.OrdersList;
                        PrintAllOrders(order);
                        return true;
                    }
                case 3:
                    {
                        PrintMessage(Constants.menuDeleteMessage);
                        int orderId = int.Parse(Console.ReadLine());
                        Orders order = _ordersService.GetOrderById(orderId);
                        if (order == null)
                            PrintMessage(Constants.idNotFoundMessage);
                        else
                        {
                            _ordersService.DeleteOrder(order);
                            string data = _ordersService.GetOrdersData();
                            _fileDatabaseService.UpdateFile3(data);
                            PrintMessage(Constants.successMessage);
                        }
                        return true;
                    }
                case 4:
                    {
                        Console.Clear();
                        return false;
                    }
                default:
                    {
                        PrintMessage(Constants.invalidInputMessage);
                        return true;
                    }

            }
        }
        public string DateNow()
        {
            return DateTime.Now.ToString("MM/dd/yyyy h:mm:ss tt");
        }
        public string NameInput()
        {
            string name = "";
            do
            {
                PrintMessage(Constants.nameMessage);
                name = Console.ReadLine();
            } while (!IsNameValid(name));
            return name;
        }
        public string PortionCountInput()
        {
            string portionCount = "";
            do
            {
                PrintMessage(Constants.portionCountMessage);
                portionCount = Console.ReadLine();
            } while (!IsDecimalValue(portionCount));
            return portionCount;
        }
        public string UnitInput()
        {
            string unit = "";
            do
            {
                PrintMessage(Constants.unitMessage);
                unit = Console.ReadLine();
            } while (!IsNameValid(unit));
            return unit;
        }
        public string PortionSizeInput()
        {
            string portionSize = "";
            do
            {
                PrintMessage(Constants.portionSizeMessage);
                portionSize = Console.ReadLine();
            } while (!IsDecimalValue(portionSize));
            return portionSize;
        }
        public string ProductsInput()
        {
            string products = "";
            do
            {
                PrintMessage(Constants.productsMessage);
                products = Console.ReadLine();
            } while (!AreProductsValid(products));

            return products;
        }
        public string MenuItemsInput()
        {
            PrintMessage(Constants.menuItemsMessage);
            string menuItems = Console.ReadLine();
            if (!AreMenuItemsValid(menuItems))
                menuItems = "ERROR";
            return menuItems;
        }
        public bool IsNameValid(string name)
        {
            if (!Regex.IsMatch(name, @"^(?! )[A-Za-z\s]*$") || _stockService.StockList.Any(stock => stock.Name == name))
            {
                Console.WriteLine(Constants.invalidParameterMessage);
                return false;
            }
            return true;
        }
        public bool IsNumberValid(string number)
        {
            if (!Regex.IsMatch(number, @"^[0-9]+$"))
            {
                Console.WriteLine(Constants.invalidParameterMessage);
                return false;
            }
                return true;
        }
        public bool AreProductsValid(string number)
        {
            if (!Regex.IsMatch(number, @"^[0-9 ]+$"))
            {
                Console.WriteLine(Constants.invalidParameterMessage);
                return false;
            }
            else
            {
                var products = number.Split(' ');
                if (products.Length != products.Distinct().Count())
                {
                    Console.WriteLine("Contains duplicates");
                    return false;
                }
                foreach (var productId in products)
                {
                    var doesContain = _stockService.StockList.Any(stock => stock.StockId == int.Parse(productId));
                    if (!doesContain)
                    {
                        Console.WriteLine(Constants.idNotFoundMessage);
                        return false;
                    }
                }
                return true;
            }
        }
        public bool AreMenuItemsValid(string number)
        {
            if (!Regex.IsMatch(number, @"^[0-9 ]+$"))
            {
                Console.WriteLine(Constants.invalidParameterMessage);
                return false;
            }
            else
            {
                var menuItems = number.Split(' ');

                foreach (var menuId in menuItems)
                {
                    var doesContainMenuId = _menuService.MenuList.Any(menu => menu.MenuId == int.Parse(menuId));

                    if (!doesContainMenuId)
                    {
                        PrintMessage(Constants.invalidParameterMessage);
                        return false;
                    }
                    var productByMenuId = _menuService.MenuList.Find(menu => menu.MenuId == int.Parse(menuId));
                    var product = productByMenuId.Products.Split(' ');
                    foreach(var stockId in product)
                    {
                        var productByStockId = _stockService.StockList.Find(stock => stock.StockId == int.Parse(stockId));
                        if(productByStockId == null )
                        {
                            PrintMessage(Constants.idNotFoundMessage);
                            return false;
                        }
                        if (double.Parse(productByStockId.PortionCount) < double.Parse(productByStockId.PortionSize))
                        {
                            PrintMessage(Constants.notEnoughStockMessage);
                            return false;
                        }
                    }
                    foreach (var stockId in product)
                    {
                        var productByStockId = _stockService.StockList.Find(stock => stock.StockId == int.Parse(stockId));
                        productByStockId.PortionCount=(double.Parse(productByStockId.PortionCount) - double.Parse(productByStockId.PortionSize)).ToString("F2");
                    }
                }
                PrintMessage(Constants.successMessage);
                return true;
            }
        }
        public bool IsDecimalValue(string number)
        {
            if (!Regex.IsMatch(number, @"^-?([0-9]\d{0,5})([.]\d{1,2})?$"))
            {
                Console.WriteLine(Constants.invalidParameterMessage);
                return false;
            }
            else
                return true;
        }
        public void PrintAllStock(List<Stock> stock)
        {
            foreach (var eachStock in stock)
            {
                PrintMessage("");
                PrintMessage(Constants.idMessage + eachStock.StockId);
                PrintMessage(Constants.nameMessage + eachStock.Name);
                PrintMessage(Constants.portionCountMessage + eachStock.PortionCount);
                PrintMessage(Constants.unitMessage + eachStock.Unit);
                PrintMessage(Constants.portionSizeMessage + eachStock.PortionSize);
                PrintMessage("");
            }
        }
        public void PrintAllMenu(List<Menu> menu)
        {
            foreach (var eachMenu in menu)
            {
                PrintMessage("");
                PrintMessage(Constants.idMessage + eachMenu.MenuId);
                PrintMessage(Constants.nameMessage + eachMenu.Name);
                PrintMessage(Constants.productsMessage + eachMenu.Products);
                PrintMessage("");
            }
        }
        public void PrintAllOrders(List<Orders> order)
        {
            foreach (var eachOrder in order)
            {
                PrintMessage("");
                PrintMessage(Constants.idMessage + eachOrder.OrderId);
                PrintMessage(Constants.nameMessage + eachOrder.DateTime);
                PrintMessage(Constants.productsMessage + eachOrder.MenuItems);
                PrintMessage("");
            }
        }
        public void UpdateStock(Stock stock)
        {
            PrintMessage(Constants.stockChoiceMessage);
            switch (GetInput())
            {
                case 1:
                    {
                        _stockService.UpdateStockName(stock, NameInput());
                        string data = _stockService.GetStockData();
                        _fileDatabaseService.UpdateFile1(data);
                        break;
                    }
                case 2:
                    {
                        _stockService.UpdateStockPortionCount(stock, PortionCountInput());
                        string data = _stockService.GetStockData();
                        _fileDatabaseService.UpdateFile1(data);
                        break;
                    }
                case 3:
                    {
                        _stockService.UpdateStockUnit(stock, UnitInput());
                        string data = _stockService.GetStockData();
                        _fileDatabaseService.UpdateFile1(data);
                        break;
                    }
                case 4:
                    {
                        _stockService.UpdateStockPortionSize(stock, PortionSizeInput());
                        string data = _stockService.GetStockData();
                        _fileDatabaseService.UpdateFile1(data);
                        break;
                    }
                case 5:
                    {
                        _stockService.UpdateStock(stock, NameInput(), PortionCountInput(), UnitInput(), PortionSizeInput());
                        string data = _stockService.GetStockData();
                        _fileDatabaseService.UpdateFile1(data);
                        break;
                    }
            }
        }
        public void UpdateMenu(Menu menu)
        {
            PrintMessage(Constants.menuChoiceMessage);
            switch (GetInput())
            {
                case 1:
                    {
                        _menuService.UpdateMenuName(menu, NameInput());
                        string data = _menuService.GetMenuData();
                        _fileDatabaseService.UpdateFile2(data);
                        break;
                    }
                case 2:
                    {
                        _menuService.UpdateProducts(menu, ProductsInput());
                        string data = _menuService.GetMenuData();
                        _fileDatabaseService.UpdateFile2(data);
                        break;
                    }
                case 3:
                    {
                        _menuService.UpdateMenu(menu, NameInput(), ProductsInput());
                        string data = _menuService.GetMenuData();
                        _fileDatabaseService.UpdateFile2(data);
                        break;
                    }
            }
        }

    }
}
