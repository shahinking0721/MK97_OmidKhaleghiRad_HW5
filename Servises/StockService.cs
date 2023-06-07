using BusinesRuleProject.Database;
using BusinesRuleProject.Domain;
using BusinesRuleProject.Interface;
using Newtonsoft.Json;
using System;
using System.Collections;
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
           string result= this.stockRepository.BuyProduct(stock);

            dbStorage.SaveChanges("Stock");
            return result;
        }

        public List<Stock> GetSalesProductList()
        {
            dbStorage.SaveChanges("TextStock");
            return stockRepository.GetSalesProductList();
          
               
            
        }

        public string SaleProduct(int productId, int cnt)
        {
          string result=  stockRepository.SaleProduct(productId, cnt);
            if (result == "true")
            {
                dbStorage.SaveChanges("Stock");
                return "susesfuuuly";
            }
            else return "wrong";
        }
        public int lastStockID()
        {
            List<Stock> stocks =stockRepository.GetSalesProductList();
            int newMyId = 0;
            foreach (var item in stocks)
            {
                if (item.StockId > newMyId)
                    newMyId = item.StockId;

            }
            return newMyId + 1;
        }

    }
}
