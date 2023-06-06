using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesRuleProject.Domain
{
    public class Stock
    {
        public Stock()
        {
                
        }
        public Stock(int stockId, string name, int productId, int productQuantity, decimal productPrice)
        {
            StockId = stockId;
            Name = name;
            ProductId = productId;
            ProductQuantity = productQuantity;
            ProductPrice = productPrice;
        }

        public int StockId { get; set; }
        public string Name { get; set; }
        public int ProductId  { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }

    }
}
