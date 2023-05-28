using BusinesRuleProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesRuleProject.Interface
{
    public  interface IProductRepository
    {
        
       string AddProduct(Product product);
       List<Product> GetProductsList();
       string GetProductById(int id);
    }
}
