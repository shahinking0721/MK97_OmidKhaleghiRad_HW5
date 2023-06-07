using BusinesRuleProject.Database;
using BusinesRuleProject.Domain;
using BusinesRuleProject.Interface;
using BusinesRuleProject.Servises;
using BusinesRuleProject.Servises.Dto;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BusinesRuleProject
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            var dBProduct = new DBStorage("ProductJson");
            var dBStock = new DBStorage("StockJson");
            var productRepository = new ProductRepository(dBProduct);
            var stockRepository = new StockRepository(dBStock);
            IProductServise productService = new ProductServise(productRepository, dBProduct);
            IStockServise stockService = new StockService(stockRepository, dBStock);
            do
            {
             beagain:   bool flag = true;
                Console.WriteLine(" *---[[[Welcome to the warehouse project]]]---*");
                Console.WriteLine(" *---[[[Please enter the desired number.]]]---*");
                Console.WriteLine("|______________________________________________|");
                Console.WriteLine(" (1)--->Add new product");
                Console.WriteLine(" (2)--->Display the list of products");
                Console.WriteLine(" (3)--->Return product name based on code");
                Console.WriteLine(" (4)--->Product purchase");
                Console.WriteLine(" (5)--->Product sales");
                Console.WriteLine(" (6)--->List of purchased products and reporting in text file");
                Console.WriteLine(" (7)--->Exit");
                Console.Write( "Please Enter your number: " ); String EnterNumber = Console.ReadLine();
                switch (EnterNumber)
                {
                     

                    case "1":
                        {
                            bool reDO = false;
                            do
                            {
                               
                                Console.Write("Product Name :"); string name = Console.ReadLine();
                                Console.Write("Product Barcode :"); string Barcode = Console.ReadLine();
                                int id = productService.lastProductID();

                                int n=0;
                                bool isNumeric = int.TryParse(Barcode, out n);
                                if (isNumeric == false) { Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine("Invalid Barcode..."); goto endline; }
                                var productAddDto = new AddPruductDto
                                {
                                    ProductId = id,
                                    Name = name,
                                   Barcode = n  
                                };
                                string result = productService.AddProduct(productAddDto);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine(result);
                                Console.ForegroundColor = ConsoleColor.White;
                                endline:  Console.Write(  "Are you want try again (y)--->YES  OR  (n)--->Exit OR (other key)--->Start again");string yORn= Console.ReadLine();if (yORn == "y") reDO = true; else if (yORn == "n")    
                                { Console.ForegroundColor = ConsoleColor.White;Console.Clear(); goto beagain;}

                            } while (reDO);
                          
                           
                                break;
                           
                        }
                        case "2":
                        {

                            List<Product> products = productService.GetProductsList();
                            Console.WriteLine("---------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("[Name]--------[IDProduct]-------[Barcode]");
                            foreach (var item in products)
                            {
                                Console.Write(item.Name); Console.Write("           "); Console.Write(item.ProductId); Console.Write("           "); Console.Write(item.Barcode);
                                Console.WriteLine();

                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.Write("Are you want start again (y)--->YES  OR  (n)--->Exit :"); string yORn = Console.ReadLine(); if (yORn == "y") { Console.Clear(); goto beagain; }
                            else if (yORn == "n")
                            { Environment.Exit(0); }
                            break;
                        }
                            case"3":
                        {
                            Console.Write("Please insert product id: ");int myid=Convert.ToInt32(Console.ReadLine());
                            string result1 = productService.GetProductById(myid);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Your Product Name is : "+result1);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.Write("Are you want start again (y)--->YES  OR  (n)--->Exit :"); string yORn = Console.ReadLine(); if (yORn == "y") { Console.Clear(); goto beagain; }
                            else if (yORn == "n")
                            { Environment.Exit(0); }
                            break;
                        }
                    case "4":
                        {
                            Console.Write("Name of product : "); string name = Console.ReadLine();
                            Console.Write("product ID : "); int id =Convert.ToInt32( Console.ReadLine());
                            Console.Write("ProductQuantity : "); int PQ = Convert.ToInt32(Console.ReadLine());
                            Console.Write("ProductPrice : "); int PP = Convert.ToInt32(Console.ReadLine());

                            int stockID = stockService.lastStockID();
                            Stock stock = new Stock()
                            {
                                StockId =stockID,
                                Name = name,
                                ProductId = id,
                                ProductQuantity = PQ,
                                ProductPrice =PP
                            };
                            string result = stockService.BuyProduct(stock);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(result);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Are you want start again (y)--->YES  OR  (n)--->Exit :"); string yORn = Console.ReadLine(); if (yORn == "y") { Console.Clear(); goto beagain; }
                            else if (yORn == "n")
                            { Environment.Exit(0); }
                            break;
                        }
                    case "5":
                        {
                            break;
                        }
                    case "6":
                        {
                            break;
                        }
                    case "7":
                        {
                            break;
                        }
                    default:
                        Console.WriteLine( "Please insert valid number...");Console.Clear(); goto beagain;
                        break;
                }while (false) ;











            } while (false);
         //   string ressult=  stockService.SaleProduct(5, 2);
          //  Console.WriteLine(ressult);
          //  List < Stock > queryStock = stockService.GetSalesProductList();
            
            //Console.WriteLine(" [Name]---------------[StockId]---------------[ProductQuantity]--------------[ProductId]--------------[ProductPrice] ");
            //foreach (var item in queryStock)
            //{
            //    Console.WriteLine(item.Name+"    "+item.StockId + "    "+ item.ProductQuantity + "    "+item.ProductId + "    "+item.ProductPrice);
            //}
           // dBStock.SaveChanges("TextStock");

          //  string result1 = productService.GetProductById(5);
          // Console.WriteLine(result1);
          // Stock stock = new Stock()
          //{
          //    StockId =(int) 2,
          //    Name = "Ali",
          //    ProductId = (int)3,
          //    ProductQuantity = (int)4,
          //    ProductPrice =(decimal) 1333



          //  };
          // string result= stockService.BuyProduct(stock);
          //  Console.WriteLine(result);
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
