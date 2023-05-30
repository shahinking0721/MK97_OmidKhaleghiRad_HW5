using BusinesRuleProject.Domain;
using BusinesRuleProject.Interface;
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
            ProductRepository productRepository = new ProductRepository();
            Product prodoct = new Product();
            bool EndProject=false;
            //string result = productRepository.GetProductById(1);
            //Console.WriteLine("Name Is: "+result);

            //do
            //{

               
                prodoct.ProductId =3;
                prodoct.Barcode = 333;
                prodoct.Name = "Amini_111";
                string resul = productRepository.AddProduct(prodoct);
                List<Product> collection1 = productRepository.GetProductsList();
                    Console.WriteLine(" [ID]------------[Name]---------[Barcode]  ");
                  
            foreach (var item in collection1)
                {
                   
                    Console.WriteLine($"   {item.ProductId}           {item.Name}          {item.Barcode}");

                }
            //    if (resul == "true")
            //    {
            //        Console.Clear();
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
