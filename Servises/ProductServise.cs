using BusinesRuleProject.Database;
using BusinesRuleProject.Domain;
using BusinesRuleProject.Interface;
using BusinesRuleProject.Servises.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinesRuleProject.Servises
{
    public class ProductServise:IProductServise
    {
        private readonly ProductRepository productRepository;
        private readonly DBStorage dbStorage;

        public ProductServise(ProductRepository productRepository,DBStorage dBStorage)
        {
            this.productRepository = productRepository; 
            this.dbStorage = dBStorage;

        }

        public string AddProduct(AddPruductDto productDto)
        {
            string result = "Wrong";
            bool myCheckResult =false;
            if (productDto.Name != null&& productDto.ProductId != null && productDto.Barcode != null)
            {
             myCheckResult = checkProductName(productDto.Name);
            }
            if (myCheckResult)
            {
                var product = new Product(productDto.ProductId, productDto.Name, productDto.Barcode);
                this.productRepository.AddProduct(product);
                dbStorage.SaveChanges("Product");
                result = "Sucssesfuly";
            }
            return result;
        }


        public string GetProductById(int id)
        {


            List<Product> products= productRepository.GetProductsList();
            var productNames = products.Where(s => s.ProductId == id);
            string nameOfProduct = string.Empty;
            if(productNames!=null)
            { 
               foreach (var item in productNames)
               {
                 nameOfProduct = item.Name;
               } 
            }
           
            return nameOfProduct;
         
        }

        public List<Product> GetProductsList()
        {
         return  productRepository.GetProductsList();
        }

        public bool checkProductName(string productName)
        {
            bool result = false;
            if (Regex.IsMatch(productName, @"[A-Z][a-z][a-z][a-z]._\d\d\d"))result = true;
            return result;
        }
    }
}
