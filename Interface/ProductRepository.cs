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
        DBStorage dBStorage = new DBStorage();
        public string AddProduct(Product product)
        {
            string Flag = "false";
            string Name = product.Name;
           
           bool result= CheckProductName(Name);
            if (result)
            {
                
                try
                {
                    dBStorage.AddProdoct(product);
                    Flag = "true";
                }
                catch (System.Exception msg)
                {

                    Console.WriteLine(msg.Message);
                 
                }
            }
            return Flag;
            
        }

        public string GetProductById(int id)
        {
            List<Product> products = dBStorage.GetProductsList();
            string result = "";
            foreach (var item in products)
            {
                if (item.ProductId == id)
                {
                    result = item.Name;
                   
                }
                
            }

            return result;
        }

        public List<Product> GetProductsList()
        {
            throw new NotImplementedException();
        }
        public bool CheckProductName(string productName)
        {
            if(Regex.IsMatch(productName, @"[A-Z][a-z][a-z][a-z]._\d\d\d"))
            {
                return true;

            }
            else return false;

            return true;

        }
    }
}
