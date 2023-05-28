using BusinesRuleProject.Domain;
using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinesRuleProject.Database
{
    public class DBStorage
    {

        static string? solutionFolderPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
        static string dataFolderPath = Path.Combine(solutionFolderPath, "Database");
        static string storagePath = Path.Combine(dataFolderPath, "ProductJson.json");
       
        public void AddProdoct(Product product)
        {
            try
            {
                //string SeryalazeText = JsonConvert.SerializeObject(product);
                //File.WriteAllText(storagePath,SeryalazeText);
                string SeryalazeText = JsonConvert.SerializeObject(product);
                File.WriteAllText(storagePath, SeryalazeText);
                string json = "";
                using (StreamReader r = new StreamReader(storagePath))
                {
                    json = r.ReadToEnd();
                

                }

                string[] array= new string[json.Length+SeryalazeText.Length+1];
                int Number = 0;
                foreach (var item in json)
                {
                 if (Number!=json.Length && Number<json.Length)   array[Number] =item.ToString();
                 else if (Number == json.Length)
                    {
                       array[Number] =",";
                       int Number2= Number+1;
                        foreach (var item2 in SeryalazeText)
                        {
                            if (Number2 != json.Length + SeryalazeText.Length && Number2 < json.Length + SeryalazeText.Length)
                            {
                                array[Number2] = item2.ToString();
                                
                            }
                            else if (Number2== json.Length + SeryalazeText.Length)
                            {
                                array[Number2] = "]";
                            }
                            Number2++;
                        }
                    }
                    

                       
                    Number++;
                }
                string writingString = "";
                foreach (var item in array)
                {
                    writingString += item.ToString();

                }

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
