using BusinesRuleProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesRuleProject.Interface
{
    public interface IStockRepository
    {

        string SaleProduct(int productId, int cnt);
        string BuyProduct(Stock productInStock);
        List<Stock> GetSalesProductList();
    }
}
