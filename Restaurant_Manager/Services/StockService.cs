using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant_Manager
{
    public class StockService
    {
        public List<Stock> StockList { get; set; }

        public StockService()
        {
            StockList = new List<Stock>();
        }

        public List<Stock> ParseStock(string[] stock)
        {
            List<Stock> stockList = new List<Stock>();

            if (stock?[0] == string.Empty)
                return stockList;

            foreach (string eachStock in stock)
            {
                string[] stockData = eachStock.Split(',');
                var temp = new Stock(stockData[1], stockData[2], stockData[3], stockData[4]);
                stockList.Add(temp);
            }

            return stockList;
        }

        public void AddStock(string name, string portionCount, string unit, string portionSize)
        {
            if(StockList.Any(s => s.Name == name))
            {
                Console.WriteLine(Constants.invalidParameterMessage);
                return;
            }
            Stock stock = new Stock(name, portionCount, unit, portionSize);
            StockList.Add(stock);
        }

        public Stock GetStockById(int Id) => StockList.Where(c => c.StockId == Id).FirstOrDefault();

        public void UpdateStock(Stock stock, string name, string portionCount, string unit, string portionSize)
        {
            if (!(name.Equals(string.Empty)) && !(portionCount.Equals(string.Empty)) && !(unit.Equals(string.Empty)) && !(portionSize.Equals(string.Empty)))
                stock.Name = name;
            stock.PortionCount = portionCount;
            stock.Unit = unit;
            stock.PortionSize = portionSize;
        }
        public void UpdateStockName(Stock stock, string name)
        {
            if (!(name.Equals(string.Empty)))
                stock.Name = name;
        }
        public void UpdateStockPortionCount(Stock stock, string portionCount)
        {
            if (!(portionCount.Equals(string.Empty)))
                stock.PortionCount = portionCount;
        }
        public void UpdateStockUnit(Stock stock, string unit)
        {
            if (!(unit.Equals(string.Empty)))
                stock.Unit = unit;
        }
        public void UpdateStockPortionSize(Stock stock, string portionSize)
        {
            if (!(portionSize.Equals(string.Empty)))
                stock.PortionSize = portionSize;
        }


        public void DeleteStock(Stock stock)
        {
            StockList.Remove(stock);
        }

        public bool IsStockListEmpty() => StockList.DefaultIfEmpty() == null ? true : false;

        public bool IsNameUnique(List<string> names, string name) => names.FindIndex(c => c.Contains(name)) >= 0 ? false : true;

        public string GetStockData()
        {
            string stockData = string.Empty;

            foreach (Stock stock in StockList)
            {
                stockData += string.Format($"{stock.StockId},{stock.Name},{stock.PortionCount},{stock.Unit},{stock.PortionSize}\n");
            }

            return stockData;
        }
    }
}
