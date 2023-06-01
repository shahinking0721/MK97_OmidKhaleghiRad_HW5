using BusinesRuleProject.Domain;
using BusinesRuleProject.Servises.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesRuleProject.Servises
{
    public interface IProductServise
    {
        string AddProduct(AddPruductDto product);
        List<Product> GetProductsList();
        string GetProductById(int id);
       
    }
}

