using BusinesRuleProject.Database;
using BusinesRuleProject.Domain;
using BusinesRuleProject.Interface;
using BusinesRuleProject.Servises.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            string result = "Invalid Name";
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
                result = "Product Saved Sucssesfuly";
            }
            return result;
        }


        public string GetProductById(int id)
        {

            string name=productRepository.GetProductById(id);
            return name;
         
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
        public int lastProductID()
        {
            List<Product> products = productRepository.GetProductsList();
            int newMyId = 0;
            foreach (var item in products)
            {
                if (item.ProductId > newMyId)
                    newMyId = item.ProductId;

            }
            return newMyId + 1;
        }

    }
}
