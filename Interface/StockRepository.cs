using BusinesRuleProject.Database;
using BusinesRuleProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
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
            dBStorage.StocksDB.Add(productInStock);
            return "";
        }

        public List<SockProductViewModel> GetSalesProductList()
        {
            throw new NotImplementedException();
        }

        public string SaleProduct(int productId, int cnt)
        {
            throw new NotImplementedException();
        }
    }
}
