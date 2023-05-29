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
            string result = productRepository.GetProductById(1);
            Console.WriteLine("Name Is: "+result);
<<<<<<< HEAD
            // git is very shirin.....

=======
            Console.WriteLine("omid");
>>>>>>> 899ba5210b51b93cda1660f11af01bef1136fe2f
            //do
            //{
                
            //    prodoct.Name = "Omidi_123";
            //    prodoct.ProductId = 1;
            //    prodoct.Barcode = 123;
            //    string resul = productRepository.AddProduct(prodoct);
            //    if (resul=="true")
            //    {
            //        Console.Clear();
            //        Console.ForegroundColor = ConsoleColor.Green;
            //        Console.WriteLine("transaction sucssesfuly...");

            //    }
            //    else if (resul=="false")
            //    {
            //        Console.Clear();
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine("transaction NOT sucssesfuly...");
            //    }
            //    Console.Write("for Exit peres  O and restsrted program peres N....:=>");
            //    string OkOrCancel= Console.ReadLine();
            //    if (OkOrCancel == "y") EndProject = true; else EndProject = false;

            //} while (EndProject);


        }
    }
}
