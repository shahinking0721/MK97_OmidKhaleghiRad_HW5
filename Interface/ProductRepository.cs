using BusinesRuleProject.Database;
using BusinesRuleProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinesRuleProject.Interface
{
    public class ProductRepository : IProductRepository
    {
        public readonly DBStorage dBStorage;
        public ProductRepository(DBStorage dBStorage)
        {
            this.dBStorage = dBStorage;
        }

        public string AddProduct(Product product)
        {
            dBStorage.productsDB.Add(product);
            return "";

        }

        public string GetProductById(int id)
        {
            return "";
            //    List<Product> products = dBStorage.GetProductsList();
            //    string result = "";
            //    foreach (var item in products)
            //    {
            //        if (item.ProductId == id)
            //        {
            //            result = item.Name;

            //        }

            // }

            //  return result;
        }

        public List<Product> GetProductsList()
        {
            return dBStorage.getAllListProduct(); 
         
        }

    }
}
