using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Restaurant_Manager.Tests
{
    [TestFixture]
    public class StockServiceTests
    {
        private List<Stock> stockList;
        private StockService stockService;
        private Stock stock1;
        public string[] stock = { "1,Chicken,10,kg,0.3\n" };
        [SetUp]
        public void Setup()
        {
            stock1 = new Stock("Chicken", "10", "kg", "0.3");
            string[] stock = { "1,Chicken,10,kg,0.3\n" };
            stockList = new List<Stock>();
            stockList.Add(stock1);
            stockService = new StockService();
        }


        [Test]
        public void ShouldReturnStockDataWithoutCommas()
        {
            List<Stock> stockData = stockService.ParseStock(stock);
            Assert.AreEqual(stockData,stockData);
        }
    }
}