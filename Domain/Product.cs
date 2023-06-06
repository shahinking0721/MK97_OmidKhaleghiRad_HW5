using BusinesRuleProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinesRuleProject.Domain
{
    public  class Product
    {
       
        public  Product(int productId, string name, int barcode)
        {
            
             Name= name;
             ProductId = productId;
             Barcode = barcode;
            

        }
    
        public int ProductId { get; set; }
        public string Name { get;private set; }
        public int Barcode { get; set; }
   
    }
    
}

