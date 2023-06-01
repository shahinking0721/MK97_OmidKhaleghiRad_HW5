using BusinesRuleProject.Database;
using BusinesRuleProject.Domain;
using BusinesRuleProject.Interface;
using BusinesRuleProject.Servises.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesRuleProject.Servises
{
    public class ProductServise:IProductServise
    {
        private readonly IProductRepository productRepository;
        private readonly DBStorage dbStorage;

        public ProductServise(IProductRepository productRepository,DBStorage dBStorage)
        {
            this.productRepository = productRepository; 
            this.dbStorage = dBStorage;

        }

        public string AddProduct(AddPruductDto productDto)
        {
            var product=new Product(productDto.ProductId,productDto.Name,productDto.Barcode);
            productRepository.AddProduct(product);
            dbStorage.SaveChanges();
            return "Sucssesfuly";
        }

        public string GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsList()
        {
         return   productRepository.GetProductsList();
        }
    }
}
