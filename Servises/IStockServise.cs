using BusinesRuleProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesRuleProject.Servises
{
    public interface IStockServise
    {
        string SaleProduct(int productId, int cnt);
        string BuyProduct(Stock productInStock);
        List<SockProductViewModel> GetSalesProductList();
    }
}
