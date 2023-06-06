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
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace BusinesRuleProject.Database
{
    public class DBStorage
    {
        private string workingDirectory;
        private string projectDirectory;
        public List<Product> productsDB;
        public List<Stock> StocksDB;
        string NameOfDB = "";
        public DBStorage(string NameofDB)
        {
            workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            JsonSerializer serializer = new JsonSerializer();

            NameOfDB = NameofDB;
          


            using (FileStream s = File.Open($"{projectDirectory}/../Database/{NameOfDB}.json", FileMode.Open))
         

                        using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                while (!sr.EndOfStream)
                {
                    if (NameOfDB == "ProductJson") productsDB = serializer.Deserialize<List<Product>>(reader);
                    if (NameOfDB == "StockJson") StocksDB = serializer.Deserialize<List<Stock>>(reader);
                }
            }
        }



        public void SaveChanges(string saveDB)
        {
            if(saveDB=="Product")
            {
                var userJsonString = JsonConvert.SerializeObject(productsDB);
                File.WriteAllText(@$"{projectDirectory}/../Database/ProductJson.json", userJsonString);
            }
            if (saveDB == "Stock")
            {
                var userJsonString = JsonConvert.SerializeObject(StocksDB);
                File.WriteAllText(@$"{projectDirectory}/../Database/StockJson.json", userJsonString);
            }
        }
        public List<Product> getAllListProduct()
        {
            return productsDB;
        }
        public List<Stock> getAllListStock()
        {
            return StocksDB;
        }
    }
}
    

