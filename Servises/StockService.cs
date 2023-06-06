using BusinesRuleProject.Database;
using BusinesRuleProject.Domain;
using BusinesRuleProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesRuleProject.Servises
{
    public class StockService : IStockServise
    {
        private readonly StockRepository stockRepository;
        private readonly DBStorage dbStorage;

        public StockService(StockRepository stockRepository, DBStorage dBStorage)
        {
            this.stockRepository = stockRepository;
            this.dbStorage = dBStorage;

        }

        public string BuyProduct(Stock productInStock)
        {
          
            var stock = new Stock(productInStock.StockId, productInStock.Name, productInStock.ProductId, productInStock.ProductQuantity, productInStock.ProductPrice);
            this.stockRepository.BuyProduct(stock);
            dbStorage.SaveChanges("Stock");
            return "success";
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
