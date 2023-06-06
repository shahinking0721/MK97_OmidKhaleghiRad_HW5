using BusinesRuleProject.Database;
using BusinesRuleProject.Domain;
using BusinesRuleProject.Interface;
using BusinesRuleProject.Servises;
using BusinesRuleProject.Servises.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesRuleProject
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
           // var dBProduct = new DBStorage("ProductJson");
            var dBStock = new DBStorage("StockJson");
         //   var productRepository = new ProductRepository(dBProduct);
            var stockRepository = new StockRepository(dBStock);
           // IProductServise productService = new ProductServise(productRepository, dBProduct);
            IStockServise stockService = new StockService(stockRepository, dBStock);
            Stock stock = new Stock()
            {
                StockId =(int) 1,
                Name = "omid",
                ProductId = (int)5,
                ProductQuantity = (int)2,
                ProductPrice =(decimal) 1000



            };
           string result= stockService.BuyProduct(stock);
            Console.WriteLine(result);
         //   string nameOfProduct=productService.GetProductById(2);
         //   Console.Write(nameOfProduct);
            //  var productAddDto = new AddPruductDto
            //  {
            //      ProductId = 2,
            //      Name = "Omidi_99",
            //      Barcode = 7,
            //  };

            //string result= productService.AddProduct(productAddDto);
            // List<Product> products= productService.GetProductsList();
            //  Console.WriteLine("[Name]--------[IDProduct]-------[Barcode]");
            //  foreach (var item in products)
            //  {
            //      Console.Write(item.Name); Console.Write("     "); Console.Write(item.ProductId); Console.Write("     "); Console.Write(item.Barcode);
            //      Console.WriteLine( );

            //  }




            //ProductRepository productRepository = new ProductRepository();
            //   Product prodoct = new Product();
            //bool EndProject = false;
            //string result = productRepository.GetProductById(1);
            //Console.WriteLine("Name Is: "+result);

            //do
            //{


            //prodoct.ProductId = 3;
            //prodoct.Barcode = 333;
            //prodoct.setProductName("Amini_111");
            //string resul = string.Empty;
            //try
            // {
            //    resul   = productRepository.AddProduct(prodoct);
            // }
            //    catch (Exception msg)
            //    {
            //        Console.BackgroundColor = ConsoleColor.Red;
            //        Console.WriteLine(msg);
            //    }

            //    List<Product> collection1 = productRepository.GetProductsList();
            //    Console.WriteLine(" [ID]------------[Name]---------[Barcode]  ");

            //    foreach (var item in collection1)
            //    {

            //        Console.WriteLine($"   {item.ProductId}           {item.Name}          {item.Barcode}");

            //    }
            //    if (resul == "true")
            //    {

            //        Console.ForegroundColor = ConsoleColor.Green;
            //        Console.WriteLine("transaction sucssesfuly...");

            //    }
            //    else if (resul == "false")
            //    {
            //        Console.Clear();
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine("transaction NOT sucssesfuly...");
            //    }
            //    Console.Write("for Exit peres  O and restsrted program peres N....:=>");
            //    string OkOrCancel = Console.ReadLine();
            //    if (OkOrCancel == "y") EndProject = true; else EndProject = false;

            //} while (EndProject);


        }
    }
}
