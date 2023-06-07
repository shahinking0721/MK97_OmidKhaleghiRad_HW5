using BusinesRuleProject.Database;
using BusinesRuleProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinesRuleProject.Interface
{
    public class StockRepository : IStockRepository
    {
        DBStorage dBStorage;
        public StockRepository(DBStorage dBStorage)
        {
            this.dBStorage = dBStorage;      
        }
        public string BuyProduct(Stock productInStock)
        {
            List<Stock> Seles = dBStorage.getAllListStock();
            // var item = (from x in Seles where x.ProductId == productId && x.ProductQuantity>=cnt select x.Name).First();
            var item = Seles.FirstOrDefault(i => i.ProductId== productInStock.ProductId || i.Name ==productInStock.Name);

            if (item != null)
            {
                item.ProductQuantity = item.ProductQuantity + productInStock.ProductQuantity;
                return "The product inventory has been updated...";
            }
            else
            {
                dBStorage.StocksDB.Add(productInStock);
                return "A new product has been created...";
            } 
        }
        public List<Stock> GetSalesProductList()
        {
            return dBStorage.getAllListStock();
        }
        public string SaleProduct(int productId, int cnt)
        {
          List<Stock> Seles= dBStorage.getAllListStock();
          var item = Seles.FirstOrDefault(i => i.ProductQuantity >= cnt && i.ProductId==productId);
            if (item != null)
            {
                item.ProductQuantity = item.ProductQuantity - cnt;
                return "The sale was successful...";
            }
            return "The sale was not successful...";
        }
    }
}
