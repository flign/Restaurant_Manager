using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Restaurant_Manager
{
    public class ConsoleUIService
    {
        StockService stockService = new StockService();
        FileDatabaseService databaseService = new FileDatabaseService();

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
                        stockService.AddStock(NameInput(), PortionCountInput(), UnitInput(), PortionSizeInput());
                        string data = stockService.GetStockData();
                        databaseService.UpdateFile(data);

                        break;
                    }
                case 2:
                    {
                        PrintMessage(Constants.stockUpdateMessage);
                        int stockId = int.Parse(Console.ReadLine());
                        Stock stock = stockService.GetStockById(stockId);
                        if (stock == null)
                            PrintMessage(Constants.idNotFoundMessage);
                        else
                        {
                            PrintMessage(Constants.stockChoiceMessage);
                            GetInput();
                            switch (input)
                            {
                                case 1:
                                    {
                                        stockService.UpdateStockName(stock, NameInput());
                                        string data = stockService.GetStockData();
                                        databaseService.UpdateFile(data);
                                        break;
                                    }
                                case 2:
                                    {
                                        stockService.UpdateStockPortionCount(stock, PortionCountInput());
                                        string data = stockService.GetStockData();
                                        databaseService.UpdateFile(data);
                                        break;
                                    }
                                case 3:
                                    {
                                        stockService.UpdateStockUnit(stock, UnitInput());
                                        string data = stockService.GetStockData();
                                        databaseService.UpdateFile(data);
                                        break;
                                    }
                                case 4:
                                    {
                                        stockService.UpdateStockPortionSize(stock, PortionSizeInput());
                                        string data = stockService.GetStockData();
                                        databaseService.UpdateFile(data);
                                        break;
                                    }
                                case 5:
                                    {
                                        stockService.UpdateStock(stock, NameInput(), PortionCountInput(), UnitInput(), PortionSizeInput());
                                        string data = stockService.GetStockData();
                                        databaseService.UpdateFile(data);
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        PrintMessage(Constants.stockDeleteMessage);
                        int stockId = int.Parse(Console.ReadLine());
                        Stock stock = stockService.GetStockById(stockId);
                        if (stock == null)
                        {
                            PrintMessage(Constants.idNotFoundMessage);
                            break;
                        }

                        stockService.DeleteStock(stock);

                        string data = stockService.GetStockData();
                        databaseService.UpdateFile(data);
                        break;
                    }
                case 4:
                    {
                        List<Stock> contacts = stockService.StockList;
                        PrintAllStock(contacts);
                        break;
                    }
            }

        }
        public string NameInput()
        {
            string name = "";
            do
            {
                PrintMessage(Constants.nameMessage);
                name = Console.ReadLine();
            } while (CheckLetters(name));
            return name;
        }
        public string PortionCountInput()
        {
            string portionCount = "";
            do
            {
                PrintMessage(Constants.portionCountMessage);
                portionCount = Console.ReadLine();
            } while (CheckNumbers(portionCount));
            return portionCount;
        }
        public string UnitInput()
        {
            string unit = "";
            do
            {
                PrintMessage(Constants.unitMessage);
                unit = Console.ReadLine();
            } while (CheckLetters(unit));
            return unit;
        }
        public string PortionSizeInput()
        {
            string portionSize = "";
            do
            {
                PrintMessage(Constants.portionSizeMessage);
                portionSize = Console.ReadLine();
            } while (CheckDecimal(portionSize));
            string unit = "";
            return portionSize;
        }
        public bool CheckLetters(string name)
        {

            if (!Regex.IsMatch(name, @"^\w[\w ]*\w$"))
            {
                Console.WriteLine(Constants.invalidParameterMessage);
                return true;
            }
            else
                return false;
        }
        public bool CheckNumbers(string number)
        {
            if (!Regex.IsMatch(number, @"^[0-9]+$"))
            {
                Console.WriteLine(Constants.invalidParameterMessage);
                return true;
            }
            else
                return false;
        }
        public bool CheckDecimal(string number)
        {
            if (!Regex.IsMatch(number, @"^-?(0\d{0,0})([.]\d{1,2})?$"))
            {
                Console.WriteLine(Constants.invalidParameterMessage);
                return true;
            }
            else
                return false;
        }
        public void PrintAllStock(List<Stock> stock)
        {
            foreach (var _stock in stock)
            {
                Console.WriteLine();
                Console.WriteLine(Constants.idMessage + _stock.StockId);
                Console.WriteLine(Constants.nameMessage + _stock.Name);
                Console.WriteLine(Constants.nameMessage + _stock.PortionCount);
                Console.WriteLine(Constants.nameMessage + _stock.Unit);
                Console.WriteLine(Constants.nameMessage + _stock.PortionSize);
                Console.WriteLine("");
            }
        }
    }
}
