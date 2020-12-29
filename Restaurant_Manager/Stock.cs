using System.Collections.Generic;
using System.Threading;

namespace Restaurant_Manager
{
    public class Stock
    {
        private static int stockId;
        public int StockId { get; private set; }
        public string Name { get; set; }
        public string PortionCount { get; set; }
        public string Unit { get; set; }
        public string PortionSize { get; set; }

        public Stock(string Name, string PortionCount, string Unit, string PortionSize)
        {
            this.Name = Name;
            this.PortionCount = PortionCount;
            this.Unit = Unit;
            this.PortionSize = PortionSize;
            StockId = Interlocked.Increment(ref stockId);
        }
    }
}
