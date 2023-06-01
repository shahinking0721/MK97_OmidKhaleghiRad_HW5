using BusinesRuleProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinesRuleProject.Domain
{
    public class Product
    {
        public Product()
        {

        }
        public Product(int productId, string name, int barcode)
        {
            ProductId = productId;
            setProductName(name);
            Barcode = barcode;
        }
    
        public int ProductId { get; set; }
        public string Name { get;private set; }
        public int Barcode { get; set; }
        public void setProductName(string productName)
        {
            try
            {
                if (Regex.IsMatch(productName, @"[A-Z][a-z][a-z][a-z]._\d\d\d"))
                {

                    Name = productName;

                }

                else
                {
                    string msg = $"The name you entered(" + productName + ") is incorrecte";
                    throw new MyCustomException(msg);

                }
            }
            catch (Exception ex) { Console.WriteLine( ex.Message); }
            
                
        }
    }
    
}

