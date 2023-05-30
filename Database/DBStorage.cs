using BusinesRuleProject.Domain;
using BusinesRuleProject.Interface;
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
        private Product omid = new Product();
        static string? solutionFolderPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
        static string dataFolderPath = Path.Combine(solutionFolderPath, "Database");
        static string storagePath = Path.Combine(dataFolderPath, "ProductJson.json");
        public string serialize(object ser)
        {
            string SeryalazeText = "";
            return SeryalazeText = JsonConvert.SerializeObject(ser);
        }

        public void AddProdoct(Product product)
        {
            string serText = serialize(product);
            string json = "";
            string ss = "";
            try
            {
                string json2 = ReadFile(storagePath);

                int n = 0;
                int l = json2.Length - 2;
                foreach (var item in json2)
                {

                    if (n <= l) ss = ss + item;
                    n++;
                }
                ss = ss + "," + serText + "]";
            }
            catch
            {
                throw new BaseExeption("can not serialized recorded");
            }
            File.WriteAllText(storagePath, ss);
           



        }

        private string ReadFile(string path)
        {
            string json = "";
            using (StreamReader read = new StreamReader(path))
            {
                json = read.ReadToEnd();

            }
            return json;
        }

        public List<Product>? GetProductsList()
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
