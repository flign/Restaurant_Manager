using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            FileDatabaseService fileDatabaseService = new FileDatabaseService();
            StockService stockService = new StockService();
            ConsoleUIService consoleUIService = new ConsoleUIService();

            string[] contactsData = fileDatabaseService.ReadStock();
            if (contactsData != null)
                stockService.StockList = stockService.ParseStock(contactsData);

            while (true)
            {
                consoleUIService.PrintMessage(Constants.menuMessage);
                int input = consoleUIService.GetInput();
                consoleUIService.ProcessInput(input);
            }
        }
    }
}
