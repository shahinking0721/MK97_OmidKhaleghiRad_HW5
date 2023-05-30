using BusinesRuleProject.Domain;
using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinesRuleProject.Database
{
    public class DBStorage
    {
        private Product omid=new Product();
        static string? solutionFolderPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
        static string dataFolderPath = Path.Combine(solutionFolderPath, "Database");
        static string storagePath = Path.Combine(dataFolderPath, "ProductJson.json");
       
        public void AddProdoct(Product product)
        {
            try
            {
               string SeryalazeText = JsonConvert.SerializeObject(product);
              //  File.WriteAllText(storagePath, SeryalazeText);


                string json = "";
                using (StreamReader r = new StreamReader(storagePath))
                {
                    json = r.ReadToEnd();


                }
                string ss = "";
                int n = 0;
                int l = json.Length - 2;
                foreach (var item in json)
                {

                 if(n<=l)   ss=ss+item;
                    n++;
                }
                ss = ss + "," + SeryalazeText + "]";
                
             //   string SeryalazeText = JsonConvert.SerializeObject(omid);



                File.WriteAllText(storagePath, ss);

            }
            catch 
            {
                throw new Exception("not recorded serialized text");
            }

          

        }
        public List<Product> GetProductsList()
        {
            var list = new List<Product>();
            using (StreamReader r = new StreamReader(storagePath))
            {
                string json = r.ReadToEnd();
              list = JsonConvert.DeserializeObject<List<Product>>(json);
            }
            return list;
         }
    }
}
